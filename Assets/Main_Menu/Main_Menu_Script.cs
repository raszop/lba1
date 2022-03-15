using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Main_Menu_Script : MonoBehaviour
{
    public Toggle volumeToggle;

    // Start is called before the first frame update
    void Start()
    {
        volumeToggle.onValueChanged.AddListener(ChangeVolume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        volumeToggle.onValueChanged.RemoveListener(ChangeVolume);
    }

    public void ChangeVolume(bool enabled)
    {
        Debug.Log("SOUND IS: " + enabled.ToString());
        AudioListener.volume = enabled ? 1f : 0f;
    }
    // On click Play_Button event
    public void Play_Button_On_Click() 
    {
        Debug.Log("play");
        SceneManager.LoadScene("gameplay");
    }

    // On click Options_Button event
    /*public void Options_Button_On_Click()
    {
        Debug.Log("OP");
    }
    */
    // On click Exit_Button event
    public void Exit_Button_On_Click()
    {
        Debug.Log("EX");
        Application.Quit();
    }
}
