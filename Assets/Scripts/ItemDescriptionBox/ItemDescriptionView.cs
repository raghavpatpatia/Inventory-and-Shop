using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescriptionView : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDescription;
    [SerializeField] private TextMeshProUGUI itemPrice;
    [SerializeField] private TextMeshProUGUI itemWeight;
    [SerializeField] private TextMeshProUGUI quantitySelectionButtonText;
    private ItemDescriptionController itemDescriptionController;
    public void SetItemDescriptionController(ItemDescriptionController itemDescriptionController) => this.itemDescriptionController = itemDescriptionController;
    public void SetItemImage(Sprite itemIcon) => itemImage.sprite = itemIcon;
    public void SetItemName(string itemName) => this.itemName.text = itemName;
    public void SetItemDescription(string itemDescription) => this.itemDescription.text = itemDescription;
    public void SetItemPrice(string priceText) => itemPrice.text = priceText;
    public void SetItemWeight(string itemWeight) => this.itemWeight.text = itemWeight;
    public void SetQuantitySelectionButtonText(string text) => quantitySelectionButtonText.text = text;
}