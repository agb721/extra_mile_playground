using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSpeedHandler : MonoBehaviour
{
    public Transform mlXRDevice;
    public Speedhandler speed;
    public Animator animator;
    public AudioSource audio;
    public TMPro.TMP_Text displayPace;

    [Tooltip("min pase as speed for running a mile")]
    public float minPerMile = 150f;
    [Tooltip("distance away from camera to wait for user")]
    public float distanceToWait = 10f;


    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        ResetAvatar();
        rb = this.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    public void ResetAvatar()
    {
        this.transform.position = new Vector3(mlXRDevice.position.x, this.transform.position.y, mlXRDevice.position.z) + (this.transform.forward * 2);
        this.transform.eulerAngles = new Vector3(0,mlXRDevice.eulerAngles.y, 0);
    }

    public void AdjustPace(bool plus)
    {
        if (plus) minPerMile+=5;
        else minPerMile-=5;
    }

    bool waiting = false;
    // Update is called once per frame
    void LateUpdate()
    {
        if (Vector3.Distance(this.transform.position, mlXRDevice.position) < distanceToWait && !waiting)
        {
            animator.SetBool("running", true);
            // then run with min speed
            rb.MovePosition(new Vector3(mlXRDevice.position.x, this.transform.position.y, this.transform.position.z)
                + ((this.transform.forward * 
                ((1760*Time.deltaTime)/minPerMile))));
        }
        else
        {
            // then stop and wait
            audio.Stop();
            waiting = true;
            animator.SetBool("running", false);
            rb.MovePosition(new Vector3(mlXRDevice.position.x, this.transform.position.y, this.transform.position.z)
                + ((this.transform.forward *
                ((1760 * Time.deltaTime) / (minPerMile*100f)))));

            if (Vector3.Distance(this.transform.position, mlXRDevice.position) < distanceToWait / 4)
            {
                waiting = false;
                audio.PlayDelayed(Time.deltaTime) ;
            }
        }

        if (Mathf.Abs(this.transform.eulerAngles.y - mlXRDevice.eulerAngles.y) > 180)
        { ResetAvatar(); }

        displayPace.text = minPerMile.ToString();

        // if (speed.speed <minSpeed)
        // rb.MovePosition(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z)
        //     + ((this.transform.forward * (0.1f))*Time.deltaTime));
        // rb.MovePosition(new Vector3(mlXRDevice.position.x, this.transform.position.y, mlXRDevice.position.z)
        //     + ((this.transform.forward * (speed.speed + 1f))));
        //this.transform.position = mlXRDevice.position + (mlXRDevice.forward * 2);
        // else
        // rb.MovePosition(new Vector3(mlXRDevice.position.x, this.transform.position.y, mlXRDevice.position.z)
        //    + ((this.transform.forward * (speed.speed * 0.1f)) + this.transform.forward));
        //  rb.MovePosition(new Vector3(mlXRDevice.transform.position.x, this.transform.position.y, mlXRDevice.transform.position.z)
        //    + (this.transform.forward * (speed.speed)*Time.deltaTime));
        //this.transform.position = mlXRDevice.position + (mlXRDevice.forward * (2*speed.speed));
    }
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.collider.name.Contains("Turn"))
           // this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y + 180, this.transform.eulerAngles.z);
    }
}