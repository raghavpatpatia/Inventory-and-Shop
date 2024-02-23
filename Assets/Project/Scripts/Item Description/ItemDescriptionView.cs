using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescriptionView : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDescription;
    [SerializeField] private TextMeshProUGUI itemPrice;
    [SerializeField] private TextMeshProUGUI descriptionBoxButtonText;
    [SerializeField] private Button descriptionBoxButton;
    private ItemDescriptionController itemDescriptionController;
    private EventService eventService;
    private void OnEnable()
    {
        eventService.ItemDescriptionBoxItemPriceText.AddListener(SetItemPrice);
        eventService.ItemDescriptionBoxButtonText.AddListener(SetDescriptionBoxButtonText);
    }
    public void SetItemDescriptionController(ItemDescriptionController itemDescriptionController) => this.itemDescriptionController = itemDescriptionController;
    public void SetEventService(EventService eventService) => this.eventService = eventService;
    public void SetItemIcon(Sprite itemIcon) => this.itemIcon.sprite = itemIcon;
    public void SetItemName(string name) => itemName.text = name;
    public void SetItemDescription(string description) => itemDescription.text = description;
    public void SetItemPrice(string price) => itemPrice.text = price;
    public void SetDescriptionBoxButtonText(string text) => this.descriptionBoxButtonText.text = text;
    private void OnDisable()
    {
        eventService.ItemDescriptionBoxItemPriceText.RemoveListener(SetItemPrice);
        eventService.ItemDescriptionBoxButtonText.RemoveListener(SetDescriptionBoxButtonText);
    }
}