using System.Collections;
using UnityEngine;
using TMPro;

public class MenuTrigger : MonoBehaviour
{
    public GameObject myCanvas;
    public GameObject lightsObject;
    public GameObject mainTextObject;
    public Transform instTransform;
    public GameObject cart;
    public Transform cartShoppingPos;
    public GameObject userRig;
    public Transform cartPos;
    public GameObject basketCanvas;
    public GameObject parentObject;
    private TextMeshProUGUI itemText;
    public GameObject productAmount;
    public GameObject itemNo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MenuTrigger") && GlobalVariables.triggerOn == true) 
        {
            // Update item numbers in basket
            itemText = itemNo.GetComponent<TextMeshProUGUI>();
            itemText.SetText(productAmount.GetComponent<ProductAmount>().productAmount.ToString());

            // Activate menu canvas and turn off lights
            myCanvas.SetActive(true);
            lightsObject.SetActive(false);

            // Turn on shopping cart canvas (item amount)
            StopAllCoroutines();
            StartCoroutine(BasketCanvasManager());

            // Transfer shopping cart to shopping position
            cart.transform.SetParent(cartShoppingPos);
            cart.transform.SetPositionAndRotation(cartShoppingPos.position, cartShoppingPos.rotation);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MenuTrigger"))
        {
            // Deactivate menu canvas and turn on lights
            myCanvas.SetActive(false);
            lightsObject.SetActive(true);

            // Remove Rigidbodies of items in cart and cart canvas
            StartCoroutine(RemoveRigidbodies());
            basketCanvas.SetActive(false);

            // Transfer shopping cart to user rig
            cart.transform.SetParent(userRig.transform);
            cart.transform.SetPositionAndRotation(cartPos.position, cartPos.rotation);
        }
    }

    IEnumerator BasketCanvasManager()
    {
        // Manage cart menu display
        basketCanvas.SetActive(true);
        yield return new WaitForSeconds(4.0f);
        basketCanvas.SetActive(false);
    }

    IEnumerator RemoveRigidbodies()
    {
        yield return new WaitForSeconds(0.5f);

        // Destroy all Rigidbodies of objects inside the shopping cart 
        Rigidbody[] childrenRB = parentObject.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rB in childrenRB)
        {
            Destroy(rB);
            // Destroy all objects outside the shopping cart
            if ((rB.transform.position.y < 0.35f) || (rB.transform.position.y > 0.9f))
            {
                Destroy(rB.gameObject);
            }
        }
    }
}
