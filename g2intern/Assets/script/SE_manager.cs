using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using myfunc;

public class SE_manager : MonoBehaviour
{
    AudioSource audio;
    public AudioClip[] sounds;

    void Start()
    {
        audio = this.GetComponent<AudioSource>();
        stsc.se_manager = this;
    }

    void Update()
    {

    }

    public void do_sound(int num_SE)
    {
        audio.PlayOneShot(sounds[num_SE]);
    }

}