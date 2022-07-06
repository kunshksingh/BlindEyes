using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class AudioPlayer : MonoBehaviour
{
    //private int outputCounter;

    //public TextMeshPro output;
    public GameObject debugSphere;
    
    
    public void PlaySound(Vector3 pos, AudioClip clip)
    {
        //output = new TextMeshPro();
        //outputCounter += 1;
        //output.text = outputCounter + " Played sound at point (" + pos.x + ", "+pos.y+", "+pos.z+") ";

        GameObject tempX = Instantiate(debugSphere, pos, Quaternion.identity);
        
        AudioSource.PlayClipAtPoint(clip, pos); //TODO Try implmenting directional sound directly upward rather than emitting sound in all directions from point
    }
}
