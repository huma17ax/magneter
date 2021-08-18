using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using myfunc;

public class polarity_switch : MonoBehaviour
{
    public SpriteRenderer sp_render;
    //public Sprite[] image_SandN = new Sprite[2];
    public GameObject[] obj_SorN = new GameObject[2];
    public bool switchByKey = true;
    public int switchTime = 5;
    private float timeCounter = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (switchByKey) {
            if (Input.GetKeyDown(KeyCode.Space)) switchPolarity();
        }
        else {
            timeCounter += Time.deltaTime;
            if (switchTime < timeCounter) {
                switchPolarity();
                timeCounter = 0;
            }
        }
    }

    void switchPolarity()
    {
        if (this.gameObject.CompareTag("S_pole"))
        {
            this.tag = "N_pole";
            //sp_render.sprite = image_SandN[1];
            obj_SorN[0].SetActive(false);
            obj_SorN[1].SetActive(true);
            stsc.find_create_obj("eff_toN", "", this.transform.position, new Vector3(0.0f, 0.0f, 0.0f), "box");
        }
        else
        {
            this.tag = "S_pole";
            //sp_render.sprite = image_SandN[0];
            obj_SorN[1].SetActive(false);
            obj_SorN[0].SetActive(true);
            stsc.find_create_obj("eff_toS", "", this.transform.position, new Vector3(0.0f, 0.0f, 0.0f), "box");
        }
    }
}
