using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class AudioFade : MonoBehaviour
{

    
    public AudioMixerSnapshot destinationSnap;
    public float transitionTime;


    // Start is called before the first frame update
     void Start()
    {
        destinationSnap.TransitionTo(transitionTime);
    }

}

