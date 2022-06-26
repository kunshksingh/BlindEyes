using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{       
    public void PlaySound(Vector3 pos, AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, pos); //TODO Try implmenting directional sound directly upward rather than emitting sound in all directions from point
    }
}
