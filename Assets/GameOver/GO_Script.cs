using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GO_Script : MonoBehaviour
{
    public Text HightScoreText;
    public Text ScoreText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        int HightScore = PlayerPrefs.GetInt("highscore", 0);
        HightScoreText.text = HightScore.ToString();
        
        int Score = PlayerPrefs.GetInt("Score", 0);
        ScoreText.text = Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButton_ToMainMenu()
    {
        SceneManager.LoadScene("Main_Menu_US");
    }
}
