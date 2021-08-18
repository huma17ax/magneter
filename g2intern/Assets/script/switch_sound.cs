using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using myfunc;


public class switch_sound : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stsc.playSE(1);
        }
    }
}
