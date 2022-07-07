using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

using UnityEngine.Windows.Speech;
using System.Linq;

using TMPro;


[RequireComponent(typeof(ARRaycastManager))]

public class AudioSweepManager : MonoBehaviour
{

    public AudioClip clip;
    public bool timerLock;


    bool manualTrigger;
    bool pointLock;
    int raysLeft;
    float timer;
    float posX;
    float posY;
    float posZ;
    
    AudioSweep sweeper;
    Vector3 cameraPos;
   
    private float angle;
    private const int raysToShoot = 20;

    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords;


    void Start()
    {
        //SpatialMappingManager.Instance.DrawVisualMeshes = false;
        timer = 0.0f;
        sweeper = new AudioSweep();
        angle = 0.0f;
        timerLock = false;
        manualTrigger = false;
        pointLock = false;
        keywords = new Dictionary<string, System.Action>();
        keywords.Add("toggle", () =>
        {
            timerLock = !timerLock;
        });
        keywords.Add("pulse", () =>
        {
            manualTrigger = true;
        });
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pointLock)
        {
            posX = transform.position.x;
            posY = transform.position.y;
            posZ = transform.position.z;
        }
        //Trigger Method Every 4.1 seconds
        timer += Time.deltaTime;
        if (timerLock)
        {
            if (timer < 4.1f)
            {
                timer = 0.0f;
            }
        }
        if (manualTrigger)
        {
            timer = 4.5f;
            manualTrigger = false;
        }
        if (timer >= 5.1f)
        {
            pointLock = false;
            timer = 0.0f;
            raysLeft = 20;
            angle = 0.0f;
        }
        else if (timer >= 4.5f & raysLeft > 0)
        {
            pointLock = true;
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
        Debug.DrawLine(transform.position, new Vector3(posX + x, posY, posZ + z)/*Direction Vector*/, Color.red, 20, false);

        if (Physics.RaycastNonAlloc(new Ray(transform.position, new Vector3(posX + x, 0, posZ + z).normalized/*Direction Vector*/), hit, 5000) >= 1)
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
    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        // if the keyword recognized is in our dictionary, call that Action.
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
    /*
    public void triggerRadarPulse()
    {
        manualTrigger = true;
    }
    public void togglePulse()
    {
        timerLock = !timerLock;
    }

    */





}
