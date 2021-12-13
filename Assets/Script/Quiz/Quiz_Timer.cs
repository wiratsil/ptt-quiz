using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quiz_Timer : MonoBehaviour
{
    //ref
    public Image timeOutUI;
    public Image timerBody;
    public Image timerBar;
    public TextMeshProUGUI timerText;

    public Sprite greenBar;
    public Sprite greenBody;
    public Sprite redBar;
    public Sprite redBody;
    [Space]

    private float timer = 0;
    private float maxTimer = 0;
    private bool timeRunning;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0 && timeRunning)
        {
            timer -= Time.deltaTime;
        }
        else if (timer <= 0 && !Quiz_GameManager.Instance.timeOut)
        {
            Quiz_GameManager.Instance.TimeOut();
            SetTimeOut();
        }

        timerText.text = Mathf.CeilToInt(timer).ToString();
        timerBar.fillAmount = timer / maxTimer;
    }

    public void SetTimer(float t)
    {
        ResetTimer();
        timer = t;
        maxTimer = t;
        timeRunning = true;
    }

    public void StopTimer()
    {
        timeRunning = false;
    }

    public void SetTimerRed()
    {
        timerBody.sprite = redBody;
        timerBar.sprite = redBar;
    }

    public void SetTimeOut()
    {
        SetTimerRed();
        timeOutUI.gameObject.SetActive(true);
    }

    public void ResetTimer()
    {
        timerBody.sprite = greenBody;
        timerBar.sprite = greenBar;
        timeOutUI.gameObject.SetActive(false);
    }
}
