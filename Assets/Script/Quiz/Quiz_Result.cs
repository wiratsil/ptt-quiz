using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class Quiz_Result : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void OpenInTab(string url);

    [SerializeField]
    private TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetResult(float score)
    {
        scoreText.text = score.ToString();
        gameObject.SetActive(true);
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void _OpenUrl(string url)
    {
        //Application.OpenURL(url);
        OpenInTab(url);
    }
}
