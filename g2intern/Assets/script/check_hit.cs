using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_hit : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == ("box"))
        {
            Debug.Log("hit");
        }
    }
}
