using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public Text timerText;
    int hours;
    int minutes;
    float seconds;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
         seconds += Time.deltaTime;
         timerText.text = hours + " : " + minutes + " : " + (int)seconds;
         if(seconds >= 60){
             minutes++;
             seconds = 0;
         }else if(minutes >= 60){
             hours++;
             minutes = 0;
         }
    }
}
