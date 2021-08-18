using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_hit : MonoBehaviour
{
    public GameObject obj_player;
    public cont_player script_cont_player;
    float offset_anchorY;
    public bool b_UPorUNDER;

    void Start()
    {
        offset_anchorY = this.transform.localPosition.y;
    }

    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("S_pole"))
        {          
            Vector2 vec_Correct = check_position(this.transform.position, other.transform.position, other.transform.localScale);
            script_cont_player.do_conect(offset_anchorY, b_UPorUNDER, vec_Correct, other.gameObject, other);
            if(other.name == "goal_magnet")
            {
                other.gameObject.GetComponent<goal_manager>().do_goal();
            }
        }
    }

    Vector2 check_position(Vector3 pos_this, Vector3 pos_hit, Vector3 scale_hit)
    {
        if(Mathf.Abs(pos_this.y - pos_hit.y) > scale_hit.y / 2.0f)
        {
            if(pos_this.y - pos_hit.y > 0)
            {
                return new Vector2(0.0f, 1.0f);
            }
            else if(Mathf.Abs(pos_this.x - pos_hit.x) > scale_hit.x / 2.0f)
            {
                return new Vector2(0.0f, 0.0f);
            }
            else if(pos_this.x - pos_hit.x > 0)
            {
                return new Vector2(0.5f, 0.6f);
            }
            else
            {
                return new Vector2(-0.5f, 0.6f);
            }
        }
        else
        {
            if(pos_this.x - pos_hit.x > 0)
            {
                return new Vector2(0.5f, 0.6f);
            }
            else
            {
                return new Vector2(-0.5f, 0.6f);
            }
        }
        //else
        //{
        //    return new Vector2(0.0f, 0.0f);
        //}
    }
}
