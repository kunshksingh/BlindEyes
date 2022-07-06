using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSweep : MonoBehaviour
{
    //private Vector3 prevPos;
    //private bool triggerable;
    //float timer;
    //bool triggered;

    AudioPlayer player;
    Camera mainCamera;
    //Vector3 position;
    //AudioClip clipCopy;
    
    void Start()
    {
       // player = new AudioPlayer();
        //triggerable = true;
        //timer = 0.0f;
        //triggered = false;
        //position = new Vector3(0, 0, 0);
        //prevPos = new Vector3(-1, 0, 0);
    }
    /*
    void Update()
    {
    
        if (triggered == true && triggerable == true) 
        {
            
            player.PlaySound(position, clipCopy);
            triggerable = false;
            triggered = false;
            prevPos = position;
        }
    }
    */
    public void trigger(Vector3 pos, AudioClip clip)
    {
        mainCamera = Camera.main;
        player = mainCamera.GetComponent<AudioPlayer>();

        player.PlaySound(pos, clip);
      

    }
}
