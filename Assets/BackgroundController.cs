using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] Color[] backgrounds;
    [SerializeField] float[] timeBreaks;
    [Header("For viewing purposes")]
    [SerializeField] bool started = false;
    [SerializeField] int curBackground;
    [SerializeField] int curTimeBreak;
    [SerializeField] float curTime;

    private void Update()
    {
        if(started)
        {
            curTime += Time.deltaTime;
            if (curTime >= timeBreaks[curTimeBreak])
            {
                Camera.main.backgroundColor = backgrounds[curBackground];
                curBackground += 1 % backgrounds.Length;
                curTimeBreak++;
                if (curTimeBreak >= timeBreaks.Length) started = false;
            }
        }
    }

    public void Reset()
    {
        started = true;
        curTime = 0;
        curBackground = 0;
        curTimeBreak = 0;
    }
}
