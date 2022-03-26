using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSpeedHandler : MonoBehaviour
{
    public Transform mlXRDevice;
    public Speedhandler speed;


    [Tooltip("min pase as speed for running a mile")]
    public float minSpeed = 6f;


    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(mlXRDevice.position.x,this.transform.position.y,mlXRDevice.position.z) + (this.transform.forward * 2);
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // if (speed.speed <minSpeed)
       // rb.MovePosition(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z)
       //     + ((this.transform.forward * (0.1f))*Time.deltaTime));
        // rb.MovePosition(new Vector3(mlXRDevice.position.x, this.transform.position.y, mlXRDevice.position.z)
        //     + ((this.transform.forward * (speed.speed + 1f))));
        //this.transform.position = mlXRDevice.position + (mlXRDevice.forward * 2);
       // else
            rb.MovePosition(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z)
                + ((this.transform.forward * (speed.speed + 0.1f)) ));
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