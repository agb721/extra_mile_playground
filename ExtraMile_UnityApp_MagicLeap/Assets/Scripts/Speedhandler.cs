using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MagicLeap;
using UnityEngine.XR.MagicLeap;
using System.Linq;

public class Speedhandler : MonoBehaviour
{
    [SerializeField]
    private Transform mlXRDevice = null;
    Vector3 prevPos;
    Vector3 currentPos;
    Vector3 posDiff;
    [SerializeField] float timedif;
    public string speedDisplay;
    [HideInInspector] public float speed;
    [SerializeField] TMPro.TMP_Text speedText;
    [HideInInspector] public int time;
    [SerializeField] TMPro.TMP_Text timeText;
    [HideInInspector] public float distance;
    [SerializeField] TMPro.TMP_Text distanceText;
    [HideInInspector] public float bpm;
    [SerializeField] TMPro.TMP_Text bpmText;
    [HideInInspector] public float flow;
    [SerializeField] TMPro.TMP_Text flowText;

    public void StartSpeedController()
    {
        prevPos = mlXRDevice.position;
        time = 0;
        timeText.text = "0.00";
        StartCoroutine(SpeedCoroutine());
        StartCoroutine(TimeCoroutine());
    }
    IEnumerator TimeCoroutine()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1);
            time++;
            var mins = time / 60;
            var secs = time % 60;
            timeText.text = mins.ToString() + ":"+secs.ToString();
            distanceText.text = CSVReader.testdata[time].ElementAt(2).Value.ToString()+"feet"+System.Environment.NewLine+
                CSVReader.testdata[time].ElementAt(3).Value.ToString() + "miles" ;
            bpmText.text = CSVReader.testdata[time].ElementAt(4).Value.ToString();
            flowText.text = CSVReader.testdata[time].ElementAt(5).Value.ToString();
        }
    }
    IEnumerator SpeedCoroutine()
    {
        while (true)
        {
            currentPos = mlXRDevice.position;
            yield return new WaitForSecondsRealtime(timedif);

            posDiff = (currentPos - prevPos) * 0.000568182f;
            speed = (float)System.Math.Round((posDiff.magnitude / timedif * 3600f), 2);
            speedDisplay = speedText.text = speed.ToString() + "m/h"+System.Environment.NewLine+
                CSVReader.testdata[time].ElementAt(1).Value.ToString()+"min/mile";

            prevPos = currentPos;
        }
    }
}
