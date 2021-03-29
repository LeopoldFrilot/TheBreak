using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public void RestartAllTracks()
    {
        GetComponent<AudioSource>().Stop();
        int numChildren = transform.childCount;
        for(int i = 0; i < numChildren; i++)
        {
            AudioSource audioSource = transform.GetChild(i).GetComponent<AudioSource>();
            audioSource.Stop();
            audioSource.Play();
        }
        var BC = FindObjectOfType<BackgroundController>();
        BC.Reset();
    }
}
