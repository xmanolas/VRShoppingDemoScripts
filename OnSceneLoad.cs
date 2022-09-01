using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// When the scene is played, run some specific functionality
/// </summary>
public class OnSceneLoad : MonoBehaviour
{
    // When scene is loaded and play begins
    public UnityEvent OnLoad = new UnityEvent();

    private void Awake()
    {
        SceneManager.sceneLoaded += PlayEvent;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= PlayEvent;
    }

    private void Start()
    {
        if (GlobalVariables.mute == true)
        {
            GameObject.Find("MuteText").GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;
        }
        else
        {
            GameObject.Find("MuteText").GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Normal;
        }

        if (GlobalVariables.movementModeOn == false)
        {
            GameObject.Find("TeleportationMode").GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;
            GameObject.Find("FirstPerson-AIO").transform.position = GameObject.Find("TeleportationPod1").transform.position;
            GameObject.Find("FirstPerson-AIO").GetComponent<FirstPersonAIO>().playerCanMove = false;
            GameObject.Find("TeleportationPod1").GetComponent<SphereCollider>().enabled = false;
            GameObject.Find("TeleportationPod2").GetComponent<SphereCollider>().enabled = true;
            GameObject.Find("TeleportationPod3").GetComponent<SphereCollider>().enabled = true;
            GameObject.Find("TeleportationPod1").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("TeleportationPod2").GetComponent<ParticleSystem>().Play();
            GameObject.Find("TeleportationPod3").GetComponent<ParticleSystem>().Play();
            GlobalVariables.teleportZone = 1;
        }
    }

    private void PlayEvent(Scene scene, LoadSceneMode mode)
    {
        OnLoad.Invoke();
    }
}
