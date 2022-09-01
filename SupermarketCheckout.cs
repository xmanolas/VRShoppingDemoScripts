using UnityEngine;
using TMPro;

public class SupermarketCheckout : MonoBehaviour
{

    public TextMeshProUGUI productTextGUI;
    public TextMeshProUGUI priceTextGUI;
    public TextMeshProUGUI multiplierTextGUI;
    public TextMeshProUGUI noVATPriceTextGUI;
    public TextMeshProUGUI percentVATTextGUI;
    public TextMeshProUGUI totalAmountTextGUI;
    public TextMeshProUGUI totalAmountGUI;
    public TextMeshProUGUI discountGUI;
    public TextMeshProUGUI grandTotal;

    private string productText;
    private string priceText;
    private string multiplierText;
    private string noVATPriceText;
    private string percentVATText;
    private string totalAmountText;
    private float totalAmount;
    public float discount;

    private void OnTriggerEnter(Collider other)
    {
        ProductAmount[] productList = GameObject.FindObjectsOfType<ProductAmount>();
        if (productList.Length > 0)
        {
            productText = "";
            priceText = "";
            multiplierText = "";
            noVATPriceText = "";
            percentVATText = "";
            totalAmountText = "";

            foreach (ProductAmount i in productList)
            {
                if (i.productAmount > 0)
                {
                    productText = productText + "\n" + i.transform.parent.name;
                    priceText = priceText + "\n€" + i.price.ToString("0.00");
                    multiplierText = multiplierText + "\n" + "x " + i.productAmount;
                    noVATPriceText = noVATPriceText + "\n€" + (i.productAmount * i.price).ToString("0.00");
                    percentVATText = percentVATText + "\n" + "20%";
                    totalAmountText = totalAmountText + "\n€" + ((i.productAmount * i.price) * 1.20).ToString("0.00");
                    totalAmount = totalAmount + (i.productAmount * i.price);
                }
            }
        }

        productTextGUI.SetText(productText);
        priceTextGUI.SetText(priceText);
        multiplierTextGUI.SetText(multiplierText);
        noVATPriceTextGUI.SetText(noVATPriceText);
        percentVATTextGUI.SetText(percentVATText);
        totalAmountTextGUI.SetText(totalAmountText);
        totalAmountGUI.SetText("€" + totalAmount.ToString("0.00"));
        discountGUI.SetText(discount.ToString("0.00") + "%");
        grandTotal.SetText("€" + (totalAmount - ((1 / discount) * totalAmount)).ToString("0.00"));

    }  
}
