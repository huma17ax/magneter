using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetPower : MonoBehaviour
{
    private bool isS = true;
    //反発する力の方向
    public Vector2 dir;
    public float power = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            Rigidbody2D rb2 = player.GetComponent<Rigidbody2D>();
            if (isS)
            {
                rb2.AddForce(dir * power);
            }
            else if(!isS)
            {
                rb2.AddForce(-dir * power);
            }
        }

    }
}
