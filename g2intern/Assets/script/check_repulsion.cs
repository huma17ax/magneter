using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_repulsion : MonoBehaviour
{
    public Rigidbody2D rbody;
    public float deff_REPULSION = 10.0f;
    Vector2 vec_repulsion = new Vector3(0.0f, 0.0f);
    bool b_cal = false;
    public cont_player script_cont_player;

    void Start()
    {
        
    }

    void Update()
    {
        if (!script_cont_player.b_conect)
        {
            rbody.AddForce(vec_repulsion.normalized * deff_REPULSION * Time.deltaTime);
        }
        if (b_cal)
        {
            vec_repulsion = new Vector3(0.0f, 0.0f);
        }
        b_cal = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("N_pole"))
        {
            vec_repulsion += check_position(this.transform.position, other.transform.position, other.transform.localScale);
            b_cal = true;
        }
        else if (other.gameObject.CompareTag("S_pole"))
        {
            vec_repulsion -= check_position(this.transform.position, other.transform.position, other.transform.localScale);
            b_cal = true;
        }
    }

    Vector2 check_position(Vector3 pos_this, Vector3 pos_hit, Vector3 scale_hit)
    {
        if (Mathf.Abs(pos_this.x - pos_hit.x) < scale_hit.x / 2.0f)
        {
            if (pos_this.y - pos_hit.y > 0)
            {
                return new Vector2(0.0f, 1.0f);
            }
            else
            {
                return new Vector2(0.0f, -1.0f);
            }
        }
        else
        {
            if (pos_this.x - pos_hit.x > 0)
            {
                return new Vector2(1.0f, 0.0f);
            }
            else
            {
                return new Vector2(-1.0f, 0.0f);
            }
        }
    }

}
