using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal_manager : MonoBehaviour
{
    public bool b_goal = false;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void do_goal()
    {
        if (!b_goal)
        {
            Debug.Log("goal");
            b_goal = true;
        }

    }

}
