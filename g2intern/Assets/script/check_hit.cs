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
            //bool b_onBox = (this.transform.position.y - other.transform.position.y > 0) && (this.transform.position.x > other.transform.position.x - other.transform.localScale.x / 2) && (this.transform.position.x < other.transform.position.x + other.transform.localScale.x / 2);
            bool b_onBox = (check_position(this.transform.position, other.transform.position, other.transform.localScale) == 0);
            script_cont_player.do_conect(offset_anchorY, b_UPorUNDER, b_onBox);
        }
    }

    int check_position(Vector3 pos_this, Vector3 pos_hit, Vector3 scale_hit)
    {
        if(Mathf.Abs(pos_this.x - pos_hit.x) < scale_hit.x / 2.0f)
        {
            if(pos_this.y - pos_hit.y > 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        else
        {
            if(pos_this.x - pos_hit.x > 0)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
    }
}
