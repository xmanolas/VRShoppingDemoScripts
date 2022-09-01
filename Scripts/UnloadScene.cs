using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class UnloadScene : MonoBehaviour
{
    public float waitTime;
    public GameObject hitGameObject;
    public UnityEvent ButtonClick = new UnityEvent();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Detect mouse click
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 2.0f))
            {
                if ((hit.transform.name == hitGameObject.transform.name))
                {
                    StartCoroutine(TimerCoroutine());
                    //Debug.Log(hitGameObject.transform.name);
                }
            }
        }
    }

    IEnumerator TimerCoroutine()
    {
        ButtonClick.Invoke();
        yield return new WaitForSeconds(waitTime);
        Application.Quit();
    }

}

