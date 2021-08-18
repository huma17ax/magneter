using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_destroy : MonoBehaviour
{
    public float time_destroy = 10;
    public bool do_dest = true;


    void Start()
    {
        if (do_dest)
        {
            Destroy(this.gameObject, time_destroy);
        }
    }

    void Update()
    {

    }

    public void now_destroy()
    {
        Destroy(this.gameObject);
    }

}