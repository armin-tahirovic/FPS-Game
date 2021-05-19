using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerFinish : MonoBehaviour
{
    public Text timerText;
    private static bool _finished;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        _finished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_finished)
            return;
                
        var time = Time.time - startTime;

        var minutes = ((int) time / 60).ToString();
        var seconds = (time % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
    }

    public static void Finish()
    {
        _finished = true;
    }
}
