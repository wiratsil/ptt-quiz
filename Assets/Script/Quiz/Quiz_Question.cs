using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Quiz_Question : MonoBehaviour
{
    public Sprite correctUI;
    public Sprite wrongUI;

    public List<Choice> choiceList;
    [System.Serializable]
    public class Choice
    {
        public GameObject button;
        public bool isCorrect;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void _Check(GameObject button)
    {
        if (Quiz_GameManager.Instance.timeOut)
            return;

        Quiz_GameManager.Instance.quiz_Timer.StopTimer();

        foreach (Choice choice in choiceList)
        {
            if (choice.button == button )
            {
                if(choice.isCorrect)
                {
                    Correct(choice);
                    return;
                }
                else
                {
                    Wrong(choice);
                    return;
                }
            }
        }
    }

    public void Correct(Choice choice)
    {
        choice.button.GetComponent<Image>().sprite = correctUI;
        Quiz_GameManager.Instance.AddScore();
        StartCoroutine(NextState());
    }

    public void Wrong(Choice choice)
    {
        choice.button.GetComponent<Image>().sprite = wrongUI;
        Quiz_GameManager.Instance.quiz_Timer.SetTimerRed();
        StartCoroutine(NextState());
    }

    public void TimeOut()
    {
        StartCoroutine(TimeOutState());
    }

    IEnumerator TimeOutState()
    {
        foreach (Choice choice in choiceList)
        {
            choice.button.GetComponent<Image>().sprite = wrongUI;
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(NextState());
    }

    //IEnumerator WrongState()
    //{
    //    yield return new WaitForSeconds(1);

    //    foreach (Choice choice in choiceList)
    //    {
    //        choice.button.GetComponent<Image>().sprite = wrongUI;
    //    }

    //    StartCoroutine(NextState());
    //}

    IEnumerator NextState()
    {
        yield return new WaitForSeconds(1);
        Quiz_GameManager.Instance.NextQuestion();
        gameObject.SetActive(false);
    }
}
