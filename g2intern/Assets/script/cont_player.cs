using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cont_player : MonoBehaviour
{
    public Rigidbody2D rbody;
    public float SPEED = 1.0f;
    public float MAX_SPEED = 10.0f;
    public bool b_conect = false;
    

    void Start()
    {
        
    }

    
    void Update()
    {
        player_move();

        if (Input.GetKey("g"))
        {
            do_conect();
        }
    }

    void player_move()
    {
        float vecX = 0.0f;
        if (Input.GetKey("a") && Input.GetKey("d"))
        {
            vecX = 0.0f;
        }
        else if (Input.GetKey("a"))
        {
            vecX = -1.0f;
        }
        else if (Input.GetKey("d"))
        {
            vecX = 1.0f;
        }
        float vecY = 0.0f;
        if (Input.GetKey("s"))
        {
            vecY = -1.0f;
        }
        else if (Input.GetKey("w"))
        {
            vecY = 1.0f;
        }
        rbody.AddForce(new Vector2(vecX, vecY) * SPEED * Time.deltaTime);
        Vector2 vec_player = rbody.velocity;
        vec_player.x = Mathf.Clamp(vec_player.x, -MAX_SPEED, MAX_SPEED);
        rbody.velocity = vec_player;
    }

    //public void do_conect(float )
    //{
    //    this.GetComponent<HingeJoint2D>().enabled = true;
    //}

}
