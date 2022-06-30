using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

using TMPro;


public class AudioSweepManager : MonoBehaviour
{
   
    public AudioClip clip;

    int outputCounter;
    float timer;
    Camera MainCamera;
    AudioSweep sweeper;
  

    protected ARRaycastManager raycastManager;


    private int raysToShoot;
  

    void Start()
    {
       
        timer = 0.0f;
        MainCamera = Camera.main;
        outputCounter = 0;
        raysToShoot = 20;
     
        
        sweeper = new AudioSweep();
    }

    // Update is called once per frame
    void Update()
    {
        //Trigger Method Every 5 seconds
        timer += Time.deltaTime;
        if (timer >= 7.0f)
        {
            TriggerRaycast();
            timer = 0.0f;
        }

    }
    //Create a raycast in the direction of the main camera
    void TriggerRaycast()
    {   
        var sweeper = new AudioSweep();


        float angle = 0;
        float shortTimer = 0.0f;
        
        for (int i = 0; i < raysToShoot; i++)
        {
            /*
             * TODO:
             * 
             * The math below does not disperse the rays properly from the main camera. 
             * Check math/code to make sure the raycasts emit 360 degrees around the main camera
             *
             */
            shortTimer = 0.0f;
            while (shortTimer < 0.3f)
            {
                shortTimer += Time.deltaTime;
            }
            float x = Mathf.Sin(angle);
            float y = Mathf.Cos(angle);
            angle += 2 * Mathf.PI / raysToShoot;

            Vector3 dir = new Vector3(transform.position.x * x, transform.position.y * y, 0);
            List<ARRaycastHit> hit = new List<ARRaycastHit>();
            Ray directionVector = new Ray(transform.position, dir);


            if (raycastManager.Raycast(directionVector, hit))
            {
                foreach(ARRaycastHit instanceHit in hit)
                {

                    Debug.Log($"Raycast hit a {instanceHit.hitType}");
                    /*if (instanceHit.hitType & TrackableType.)
                    {
                        sweeper.trigger(hit[0].point, clip);
                    }*/
                }
            }
        }
        /*
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
        */
    }



}
