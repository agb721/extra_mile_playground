using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.MagicLeap;

public class DynamicBimController : MonoBehaviour
{

    public GameObject controller;
    public LineRenderer beam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = controller.transform.position;
        transform.rotation = controller.transform.rotation;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            beam.useWorldSpace = true;
            beam.SetPosition(0, transform.position);
            beam.SetPosition(1, hit.point);
        }
        else {
            beam.useWorldSpace = false;
            beam.SetPosition(0, transform.position);
            beam.SetPosition(1, transform.forward * 5);
        }
    }
}
