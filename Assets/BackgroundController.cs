using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] Material[] skyboxes;
    [SerializeField] float[] rotationSpeeds;
    [SerializeField] Vector3[] axisOfRotations;
    [SerializeField] float[] timeBreaks;

    [Header("For viewing purposes")]
    [SerializeField] bool started = false;
    [SerializeField] int curSkybox;
    [SerializeField] int curTimeBreak;
    [SerializeField] float curTime;

    // Cached references
    Rotate rotateScript;

    private void Awake()
    {
        rotateScript = FindObjectOfType<Rotate>();
    }
    private void Update()
    {
        if(started)
        {
            curTime += Time.deltaTime;
            if (curTime >= timeBreaks[curTimeBreak])
            {
                RenderSettings.skybox = skyboxes[curSkybox];
                rotateScript.rotateSpeed = rotationSpeeds[curSkybox];
                rotateScript.axis = axisOfRotations[curSkybox];
                curSkybox = (curSkybox + 1) % skyboxes.Length;
                curTimeBreak++;
                if (curTimeBreak >= timeBreaks.Length)
                {
                    started = false;
                }
            }
        }
    }

    public void Reset()
    {
        started = true;
        curTime = 0;
        curSkybox = 0;
        curTimeBreak = 0;
    }
}
