using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailDisplay : MonoBehaviour
{
    public LineRenderer line;
   [SerializeField]public Transform end;
    [SerializeField] public Transform start;

    // Start is called before the first frame update
    void Start()
    {
        line.useWorldSpace = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        line.SetPosition(0, end.position);
        line.SetPosition(1, start.position);
    }
}
