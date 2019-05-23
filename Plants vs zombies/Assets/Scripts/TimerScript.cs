using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Text TimeText;
    private float StartTime;
    
    void Start()
    {
        StartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - StartTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        if (t%60 >= 0 && t%60 < 9.999) TimeText.text = minutes + ":0" + seconds;
        else TimeText.text = minutes + ":" + seconds;
    }
}
