using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSweep : MonoBehaviour
{
    private Vector3 prevPos;
    bool triggerable;
    //float timer;
    private bool triggered;
    AudioPlayer player;
    Vector3 position;
    AudioClip clipCopy;
    
    void Start()
    {
        player = new AudioPlayer();
        triggerable = true;
        //timer = 0.0f;
        triggered = false;
        position = new Vector3(0, 0, 0);
        prevPos = new Vector3(-1, 0, 0);
    }

    void Update()
    {
        
        //timer += Time.deltaTime;
        if (/*timer >= 4.0f */ position != prevPos && !triggerable)
        {
            prevPos = position;
            triggerable = true;
            //timer = 0.0f;
        }
        if (triggered && triggerable) 
        {
            player.PlaySound(position, clipCopy);
            triggerable = false;
            triggered = false;
        }
    }
    public void trigger(Vector3 pos, AudioClip clip)
    {
        if (triggerable)
        {
            position = pos;
            clipCopy = clip;
            triggered = true;
        }
        
    }
}
