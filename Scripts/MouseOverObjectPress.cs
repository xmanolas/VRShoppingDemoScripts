using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseOverObjectPress : MonoBehaviour
{

    public GameObject myCanvas;

    void OnMouseDown()
    {
        // Destroy the gameObject after clicking on it
        myCanvas.SetActive(true);
    }
}
