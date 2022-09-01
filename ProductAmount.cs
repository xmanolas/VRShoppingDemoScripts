using UnityEngine;

public class ProductAmount : MonoBehaviour
{
    public int prodID;
    public int productAmount;
    public float price;
    //public ProductDescription productDescSO;

    private void Awake()
    {
        productAmount = GameObject.Find("AppDataManager").GetComponent<PersistentDataManager>().productAmounts[prodID];
       // price = productDescSO.price;
    }
}
