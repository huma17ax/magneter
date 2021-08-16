using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cont_player : MonoBehaviour
{
    public Rigidbody2D rbody;
    public float SPEED = 1.0f;
    public float MAX_SPEED = 10.0f;
    public float maxAngle = 45;
    public Vector2 nomalVec;
    [SerializeField] private Vector2 maxVec;
    [SerializeField] private Vector2 minVec;

    void Start()
    {
        
    }

    
    void Update()
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
        rbody.AddForce(new Vector2(vecX, 0.0f) * SPEED * Time.deltaTime);
        Vector2 vec_player = rbody.velocity;
        vec_player.x = Mathf.Clamp(vec_player.x, -MAX_SPEED, MAX_SPEED);
        rbody.velocity = vec_player;
    }
}
