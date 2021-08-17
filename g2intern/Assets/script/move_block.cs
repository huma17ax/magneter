using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_block : MonoBehaviour
{
    public Vector3 dir_move;
    public float time_move = 1.0f;
    bool b_go = true;
    float time_count = 0.0f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (b_go)
        {
            this.transform.position += dir_move * Time.deltaTime;
        }
        else
        {
            this.transform.position -= dir_move * Time.deltaTime;
        }
        time_count += Time.deltaTime;
        if(time_count > time_move)
        {
            time_count -= time_move;
            b_go = !b_go;
        }
    }
}
