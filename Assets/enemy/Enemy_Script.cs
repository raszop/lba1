using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
    public bool Can_Rotate = false;
    public bool Clockwise = false;
    public float Rotation_Speed = 0;
    // Start is called before the first frame update
    void Start()
    {
       
           
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Can_Rotate == true)
        {
            if (Clockwise == true)
            {
                gameObject.transform.Rotate(0, 0, Rotation_Speed);
            }
            else
            {
                gameObject.transform.Rotate(0, 0, -Rotation_Speed);
            }
        }
    }
}
