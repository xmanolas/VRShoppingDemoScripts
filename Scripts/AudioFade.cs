using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

// Shortcut editor audio transitions
public class AudioFade : MonoBehaviour
{

    public AudioMixerSnapshot destinationSnap;
    public float transitionTime;

     void Start()
    {
        destinationSnap.TransitionTo(transitionTime);
    }

}

