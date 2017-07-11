using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    private static int cDefaultTimer = 120000;
    private static int MILLISECPERHOUR = 3600000;
    private static int MILLISECPERMIN = 60000;
    private static int MILLISECPERSEC = 1000;

    public Text TimerString;
    public Text TimerButtonString;

    protected int mTimer = 120000;
    protected bool mRunning = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (mRunning)
        {
            mTimer -= (int)(Time.deltaTime * 1000);

            if (mTimer <= 0)
            {
                mTimer = 0;
                mRunning = false;

                if (TimerButtonString != null)
                {
                    TimerButtonString.text = "DONE!";
                }
            }

            UpdateTimerString();
        }
    }

    public void OnTimerResetPressed()
    {
        //Debug.Log("Reset Pressed");
        mTimer = cDefaultTimer;
        mRunning = false;

        UpdateTimerString();

        if (TimerButtonString != null)
        {
            TimerButtonString.text = "START";
        }
    }

    protected void UpdateTimerString()
    {
        if (TimerString == null)
            return;

        //TimeSpan time = new TimeSpan(0, 0, 0, 0, milliSec);
        int initial = mTimer;
        //int hour = (int)(initial / MILLISECPERHOUR);
        //initial -= (hour * MILLISECPERHOUR);
        int min = (int)(initial / MILLISECPERMIN);
        initial -= (min * MILLISECPERMIN);
        int sec = (int)(initial / MILLISECPERSEC);
        initial -= (sec * MILLISECPERSEC);

        //initial will now contain the ms remaining - we only care about two digits of that so truncate it
        initial = (int)(initial / 10);

        TimerString.text = string.Format("{0:D2}:{1:D2}:{2:D2}", min, sec, initial);
    }

    public void OnTimerButtonPressed()
    {
        //Debug.Log("Timer Button Pressed");
        mRunning = !mRunning;

        if (TimerButtonString != null)
        {
            if (mRunning)
            {
                TimerButtonString.text = "PAUSE";
            }
            else
            {
                TimerButtonString.text = "START";
            }
        }
    }
}
