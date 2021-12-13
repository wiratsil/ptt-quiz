using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quiz_GameManager : Singleton<Quiz_GameManager>
{
    //ref
    public List<Quiz_Question> questionList;
    public Canvas gameCanvas;
    public Quiz_Timer quiz_Timer;
    public TextMeshProUGUI scoreText;
    public Quiz_Result quiz_Result;

    //setting
    [Space]
    public int numQuestion = 5;
    public float timer = 16;

    public bool timeOut;

    private Quiz_Question quizClone;
    private int score = 0;
    private List<int> usedValues = new List<int>();
    private List<Quiz_Question> cloneList = new List<Quiz_Question>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StarGame()
    {
        ResetUniqueNumber();
        for(int i = 0; i < numQuestion; i ++)
        {
            int index = UniqueRandomInt(0, questionList.Count);
            Quiz_Question clone = Instantiate(questionList[index], gameCanvas.transform);
            clone.gameObject.SetActive(false);
            cloneList.Add(clone);
        }
        NextQuestion();
    }

    public void NextQuestion()
    {
        if (cloneList.Count <= 0)
        {
            Result();
            return;
        }
        timeOut = false;
        quizClone = cloneList[0];
        cloneList.RemoveAt(0);
        quiz_Timer.SetTimer(timer);
        quizClone.gameObject.SetActive(true);
    }

    public int UniqueRandomInt(int min, int max)
    {
        int val = Random.Range(min, max);
        float timeLoop = 0;
        while (usedValues.Contains(val))
        {
            val = Random.Range(min, max);
            timeLoop += Time.deltaTime ;
            if (timeLoop > 3)
                return -1;
        }
        usedValues.Add(val);
        return val;
    }

    public void ResetUniqueNumber()
    {
        usedValues.Clear();
    }

    public void AddScore ()
    {
        score += 10;
        scoreText.text = score.ToString();
    }

    public void TimeOut()
    {
        timeOut = true;
        quizClone.TimeOut();
    }

    public void Result()
    {
        quiz_Result.SetResult(score);
        API_AddScore.Instance.AddScore(score);
    }
}
