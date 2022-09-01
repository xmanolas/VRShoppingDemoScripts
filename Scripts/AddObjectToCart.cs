using System.Collections;
using UnityEngine;
using TMPro;

public class AddObjectToCart : MonoBehaviour
{
    public GameObject hitGameObject;
    public GameObject destGameObject;
    public GameObject myPrefab;
    public GameObject basketCanvas;
    public GameObject itemNo;
    public GameObject parentObject;
    public GameObject productAmount;
    private TextMeshProUGUI itemText;
    private GameObject localGO;

    void Awake()
    {
        // Update cart TextMeshPro
        itemText = itemNo.GetComponent<TextMeshProUGUI>();
        itemText.SetText(productAmount.GetComponent<ProductAmount>().productAmount.ToString());
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            // Update cart TextMeshPro
            itemText.SetText(productAmount.GetComponent<ProductAmount>().productAmount.ToString());

            // Detect mouse click
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 2.0f))
            {
                if ((hit.transform.name == hitGameObject.transform.name))
                {
                    // Instantiate product model and add to cart
                    localGO = Instantiate(myPrefab, destGameObject.transform.position, Quaternion.identity);
                    localGO.transform.SetParent(parentObject.transform);

                    // Remove Rigidbodies of items in cart
                    StopAllCoroutines();
                    StartCoroutine(RemoveRigidbodies());
                    StartCoroutine(BasketCanvasManager());

                    // Update item numbers in basket
                    productAmount.GetComponent<ProductAmount>().productAmount++;
                    GameObject.Find("AppDataManager").GetComponent<PersistentDataManager>().productAmounts[productAmount.GetComponent<ProductAmount>().prodID] = productAmount.GetComponent<ProductAmount>().productAmount;
                    itemText.SetText(productAmount.GetComponent<ProductAmount>().productAmount.ToString());
                }
            }
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
        yield return new WaitForSeconds(1.0f);

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
    



