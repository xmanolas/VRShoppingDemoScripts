using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.Events;

public class GameObjectSceneTrigger : MonoBehaviour
{
    public string sceneName;
    public Transform curGameObjectTransform;
    public AudioMixerSnapshot destinationSnap;
    public float waitTime;
    public float audioTransitionTime;
    public UnityEvent ButtonClick = new UnityEvent();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == curGameObjectTransform.name)
                {
                    StartCoroutine(TimerCoroutine());
                }
            }
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
