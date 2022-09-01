using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSPlayerInteractionController : MonoBehaviour
{


    [Header("Interaction Settings")]
    public float maxDistance = 5;
    public LayerMask interactableLayers;

    [Header("UI - Adapt to fit app")]
    public Button interactButton;

    private FPSInteractable currentInteractable;


    // Update is called once per frame
    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, maxDistance, interactableLayers))
        { 
            currentInteractable = hit.collider.GetComponent<FPSInteractable>();
        }
        else currentInteractable = null;

        interactButton.interactable = currentInteractable != null;
    }

    public void Interact()
    {
        if (currentInteractable) currentInteractable.OnInteraction();
    }
}
