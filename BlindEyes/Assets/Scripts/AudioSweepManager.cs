using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;


using TMPro;


[RequireComponent(typeof(ARRaycastManager))]

public class AudioSweepManager : MonoBehaviour
{

    public AudioClip clip;
    public bool isEnabled;

    float timer;

    AudioSweep sweeper;
    float posX;
    float posY;
    float posZ;
    Vector3 cameraPos;
    int raysLeft;

    private float angle;
    private const int raysToShoot = 20;

    void Start()
    {
        //SpatialMappingManager.Instance.DrawVisualMeshes = false;
        timer = 0.0f;
        sweeper = new AudioSweep();
        angle = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Trigger Method Every 7 seconds
        timer += Time.deltaTime;
        if (timer >= 5.1f)
        {
            timer = 0.0f;
            raysLeft = 20;
            angle = 0.0f;
        }
        else if (timer >= 4.5f & raysLeft > 0)
        {
            timer -= 0.4f;
            raysLeft -= 1;
            angle += 2 * Mathf.PI / raysToShoot;
            TriggerRaycast(angle);
        }

    }

    void TriggerRaycast(float angle)
    {
        var sweeper = new AudioSweep();

        float x = Mathf.Cos(angle);
        float z = Mathf.Sin(angle);

        RaycastHit[] hit = new RaycastHit[1];
        
        //Vizualize Direction Vector
        //Debug.DrawLine(transform.position, new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z)/*Direction Vector*/, Color.red, 20, false);

        if (Physics.RaycastNonAlloc(new Ray(transform.position, new Vector3(transform.position.x + x, posY, transform.position.z + z)/*Direction Vector*/), hit, 5000) >= 1)
        {
 
            for(int i = 0; i<hit.Length; i++)
            {
                if (!(hit[i].collider.gameObject == null) & hit[i].collider.gameObject.tag == "SoundMesh")
                {
                   
                    sweeper.trigger(hit[0].point, clip);

                }
            }

        }

    }







}
