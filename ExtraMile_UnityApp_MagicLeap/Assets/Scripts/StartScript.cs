using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartScript : MonoBehaviour
{
    [SerializeField]public GameObject theGuy;
    [SerializeField]public GameObject ui;
    public int countdown =5;
    [SerializeField]public TMP_Text countdowntext;
    [SerializeField]
    public Speedhandler speedController;
    // Start is called before the first frame update
    void Start()
    {
        countdowntext.text = countdown.ToString() ;
        StartCoroutine(countdownIT(0));
    }
    IEnumerator countdownIT(int initialDelay)
    {
        yield return new WaitForSeconds(initialDelay);
        var condition = true;
        while (condition)
        {
            yield return new WaitForSeconds(1);
            countdown--;
            countdowntext.text = countdown.ToString();

            if (countdown == -1)
                condition = false;
        }

        DoStart();

    }
    void DoStart()
    {
        
        theGuy.SetActive(true);
        ui.SetActive(true);
        this.gameObject.SetActive(false);
        speedController.StartSpeedController();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
