using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.Events;

public class SceneTransition : MonoBehaviour
{
    public string sceneName;
    public KeyCode tempKey;
    public float waitTime;
    public float audioTransitionTime;
    public AudioMixerSnapshot destinationSnap;

    public UnityEvent ButtonClick = new UnityEvent();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(tempKey))
        {
            StartCoroutine(TimerCoroutine());
        }
    }

    IEnumerator TimerCoroutine()
    {
        destinationSnap.TransitionTo(audioTransitionTime);
        ButtonClick.Invoke();
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneName);
    }
}