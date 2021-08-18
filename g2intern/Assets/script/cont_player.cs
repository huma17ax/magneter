using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cont_player : MonoBehaviour
{
    public Rigidbody2D rbody;
    public float SPEED = 1.0f;
    public float MAX_SPEED = 10.0f;
    public float FORCE_ROTA = 1.0f;
    public float POWER_REPULSION = 10.0f;
    public Collider2D b_conect = null;
    public HingeJoint2D hing2d;
    public GameObject[] obj_checkCircle = new GameObject[2];
    bool b_stand = true;
    Vector2 vec_correct = new Vector2(0.0f, 0.0f);

    void Start()
    {
        
    }

    
    void Update()
    {
        if (!b_conect)
        {
            //player_move();
        }
        else
        {
            conect_move();
        }

        if (b_conect && b_conect.tag == "N_pole")
        {
            do_repulsion();
        }

        // スタートに戻る
        if (Input.GetKey("r")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void player_move()
    {
        float vecX = 0.0f;
        if (Input.GetKey("a"))
        {
            vecX += -1.0f;
        }
        if (Input.GetKey("d"))
        {
            vecX += 1.0f;
        }
        rbody.AddForce(new Vector2(vecX, 0.0f) * SPEED * Time.deltaTime);
        //rbody.AddTorque(- FORCE_ROTA * Time.deltaTime * vecX, ForceMode2D.Impulse);
        Vector2 vec_player = rbody.velocity;
        vec_player.x = Mathf.Clamp(vec_player.x, -MAX_SPEED, MAX_SPEED);
        rbody.velocity = vec_player;
        Debug.Log(rbody.velocity.x);
    }

    void conect_move()
    {
        float vecX = 0.0f;
        if (Input.GetKey("a"))
        {
            vecX += -1.0f;
        }
        if (Input.GetKey("d"))
        {
            vecX += 1.0f;
        }
        //float vecY = 0.0f;
        //if (Input.GetKey("s"))
        //{
        //    vecY += -1.0f;
        //}
        //if (Input.GetKey("w"))
        //{
        //    vecY += 1.0f;
        //}
        rbody.AddForce((new Vector2(vecX, 0.0f) + vec_correct) * SPEED * Time.deltaTime);
    }

    public void do_conect(float PosAnchorY, bool b_Stand, Vector2 v_correct, GameObject obj_parent, Collider2D connected_block)
    {
        if (!b_conect)
        {
            var emptyObject = new GameObject();
            emptyObject.transform.parent = obj_parent.transform;
            this.transform.parent = emptyObject.transform;
            hing2d.enabled = true;
            hing2d.anchor = new Vector2(0.0f, PosAnchorY);
            b_conect = connected_block;
            vec_correct = v_correct;
            b_stand = !b_Stand;
        }
    }

    public void do_repulsion()
    {
        if (b_conect)
        {
            GameObject obj_parent = this.gameObject.transform.parent.gameObject;
            this.gameObject.transform.parent = null;
            Destroy(obj_parent);
            hing2d.enabled = false;
            Vector2 vec_repulsion = (obj_checkCircle[0].transform.position - obj_checkCircle[1].transform.position).normalized;
            if (!b_stand)
            {
                vec_repulsion *= -1.0f;
            }
            b_conect = null;
            rbody.AddForce(vec_repulsion * POWER_REPULSION);
        }
    }

}
