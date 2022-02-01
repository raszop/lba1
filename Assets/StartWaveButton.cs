using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWaveButton : MonoBehaviour
{
    public GameController gameController;

    public bool canStartWave = false;

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.E))
        {
            if (canStartWave == true)
            {
                gameController.StartWave();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            canStartWave = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            canStartWave = false;
        }
    }
}
