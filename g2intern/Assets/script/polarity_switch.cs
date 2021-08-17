using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class polarity_switch : MonoBehaviour
{
    public SpriteRenderer sp_render;
    public Sprite[] image_SandN = new Sprite[2];

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (this.gameObject.CompareTag("S_pole"))
            {
                this.tag = "N_pole";
                sp_render.sprite = image_SandN[1];
            }
            else
            {
                this.tag = "S_pole";
                sp_render.sprite = image_SandN[0];
            }
        }
    }
}
