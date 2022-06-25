using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioManager : MonoBehaviour
{
    float timer;
    RaycastHit[] m_Results;
    Camera MainCamera;
    public TextMeshPro output;
    int outputCounter;


    void Start()
    {
        m_Results = new RaycastHit[2];        
        timer = 0.0f;
        MainCamera = Camera.main;
        outputCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Trigger Method Every 5 seconds
        timer += Time.deltaTime;
        if (timer / 5.0f >= 1.0f)
        {
            TriggerRaycast();
            timer = 0.0f;
        }
        
    }
    //Create a raycast in the direction of the main camera
    void TriggerRaycast()
    {
        outputCounter += 1;
        var layerMask = ~0;
        int hits = Physics.RaycastNonAlloc(MainCamera.transform.position, transform.forward, m_Results, 1000, layerMask);
        for (int i = 0; i < hits; i++)
        {
            output.text = outputCounter + " Hit " + m_Results[i].collider.gameObject.name;
        }
        if (hits == 0)
        {
            output.text = outputCounter + " Did not hit";
        }

    }
    


}
