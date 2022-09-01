using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.Events;

public class GoToNaturePod : MonoBehaviour
{
    string sceneName = "NaturePod";
    public float waitTime;
    public float audioTransitionTime;
    public AudioMixerSnapshot destinationSnap;

    //  public UnityEvent ButtonClick = new UnityEvent();

    // Update is called once per frame
    public void Run()
    {
        StartCoroutine(TimerCoroutine());
    }


    IEnumerator TimerCoroutine()
    {
        destinationSnap.TransitionTo(audioTransitionTime);
        //ButtonClick.Invoke();
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneName);
    }

}
