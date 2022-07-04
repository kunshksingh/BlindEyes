using System;
using System.Collections;
using System.Collections.Generic;
//using System.Threading;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;


using TMPro;


[RequireComponent(typeof(ARRaycastManager))]

public class AudioSweepManager : MonoBehaviour
{
   
    public AudioClip clip;

    //int outputCounter;
    float timer;
    Camera MainCamera;
    AudioSweep sweeper;

    ARRaycastManager raycastManager;



    private const int raysToShoot = 20;
  

    void Start()
    {
        //raycastManager = GetComponent<ARRaycastManger>();
        timer = 0.0f;
        MainCamera = Camera.main;
        //outputCounter = 0;
     
        
        sweeper = new AudioSweep();
    }

    // Update is called once per frame
    void Update()
    {
        //Trigger Method Every 7 seconds
        timer += Time.deltaTime;
        if (timer >= 7.0f)
        {
            TriggerRaycast();
            timer = 0.0f;
        }

    }
    void stallThreat()
    {
        float shortTimer = 0.0f;
        while (shortTimer < 1.0f)
        {
            shortTimer += Time.deltaTime;
        }
    }
    //Create a raycast in the direction of the main camera
    void TriggerRaycast()
    {   
     
        var sweeper = new AudioSweep();

      

        float angle = 0;
    
        
        for (int i = 0; i < raysToShoot; i++)
        {
            
            
            angle += 2 * 2 * Mathf.PI / raysToShoot;
            float x = Mathf.Cos(angle);
            float z = Mathf.Sin(angle);
     
            RaycastHit[] hit = new RaycastHit[10];
            Debug.Log((angle*180)/(2*Mathf.PI));
           
            Debug.DrawLine(MainCamera.transform.position, new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z)/*Direction Vector*/, Color.red, 20, false);
                  
            if (Physics.RaycastNonAlloc(new Ray(transform.position, new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z)/*Direction Vector*/), hit, 1000) >= 1)
            {
                Debug.Log("Hit!");
                foreach (RaycastHit instanceHit in hit)
                {
                    if (instanceHit.collider.gameObject.tag == "SoundMesh")
                    {
                        //Debug.Log("Hit: " + instanceHit.collider.gameObject.name);
                        //Debug.Log("Hit: " + instanceHit.collider.gameObject.tag);
                        //Debug.Log("Hit: " + instanceHit.collider.gameObject.transform.position);
                        //Debug.Log("Hit: " + instanceHit.collider.gameObject.transform.rotation);
                        //Debug.Log("Hit: " + instanceHit.collider.gameObject.transform.localScale);
                        //Debug.Log("Hit: " + instanceHit.collider.gameObject.transform.parent.name);
                        //Debug.Log("Hit: " + instanceHit.collider.gameObject.transform.parent.tag);
                        //Debug.Log("Hit: " + instanceHit.collider.gameObject.transform.parent.transform.position);
                        //Debug.Log("Hit: " + instanceHit.collider.gameObject.transform.parent.transform.rotation);
                        //Debug.Log("Hit: " + instanceHit.collider.gameObject.transform.parent.transform.localScale);
                        //Debug.Log("Hit: " + instanceHit.collider.gameObject.transform.parent.transform.parent.name);
                        //Debug.Log("Hit: " + instanceHit.collider.gameObject.transform.parent.transform.parent.tag);
                        //Debug.Log("Hit: " + instanceHit.collider.gameObject.transform.parent.transform.parent.transform.position);
                        //Debug.Log("Hit: " + instanceHit.collider.gameObject.transform.parent.transform.parent.transform.rotation);
                        //Debug.Log("Hit: " + instanceHit.collider.gameObject.transform.parent.transform.parent.transform.localScale);
                        //Debug.Log("Hit: " + instanceHit.collider.gameObject.transform.parent.transform.parent.transform.parent.name);
                        //Debug.Log("Hit: " + instanceHit.collider.gameObject.transform.parent.transform.parent.transform.parent.tag);
                       

                        sweeper.trigger(hit[0].point, clip);
                    }
                   
                }

            }

            //List<ARRaycastHit> ARHit = new List<ARRaycastHit>();
      

            /*
            if (raycastManager.Raycast(directionVector, ARHit))
            {
                foreach(ARRaycastHit instanceHit in ARHit)
                {
                    
                    Debug.Log($"Raycast hit a {instanceHit.ARHitType}");
                    if (instanceHit.hitType & TrackableType.)
                    {
                        sweeper.trigger(hit[0].point, clip);
                    }
                    
                }
            }
            */
            
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
