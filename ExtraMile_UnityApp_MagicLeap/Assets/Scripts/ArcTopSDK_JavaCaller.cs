using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcTopSDK_JavaCaller : MonoBehaviour
{
    AndroidJavaObject jo = null;
    public TMPro.TMP_Text debug = null;
    // Start is called before the first frame update
    void Start()
    {
        jo = new AndroidJavaObject("gradle-wrapper");
    }


    public void Call_it()
    {
        if(debug != null)
            debug.text  = "found java library: " + (jo == null); ;
        //jo.CallStatic();
    }
}
