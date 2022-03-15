using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // On click Play_Button event
    public void Play_Button_On_Click() 
    {
        Debug.Log("play");
        SceneManager.LoadScene("gameplay");
    }

    // On click Options_Button event
    public void Options_Button_On_Click()
    {
        Debug.Log("OP");
    }

    // On click Exit_Button event
    public void Exit_Button_On_Click()
    {
        Debug.Log("EX");
        Application.Quit();
    }
}
