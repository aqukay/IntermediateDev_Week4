using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    public float TimerLeft;
    public bool TimerOn = false;

    public TMP_Text TimerText;

    // Start is called before the first frame update
    void Start()
    {
        TimerOn = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (TimerOn)
        {
            if (TimerLeft > 0)
            {
                TimerLeft -= Time.deltaTime;
                updateTimer(TimerLeft);
            }
            else 
            {
                Debug.Log("Time is up");
                TimerLeft = 0;
                TimerOn = false;
                SceneManager.LoadScene("Main");
            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
