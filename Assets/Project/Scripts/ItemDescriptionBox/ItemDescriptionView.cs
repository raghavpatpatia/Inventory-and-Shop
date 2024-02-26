using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescriptionView : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDescription;
    [SerializeField] private TextMeshProUGUI itemPrice;
    [SerializeField] private TextMeshProUGUI quantitySelectionButtonText;
    [SerializeField] private Button quantitySelectionButton;

    private EventService eventService;
    public void Init(EventService eventService)
    {
        this.eventService = eventService;
        eventService.ItemDescriptionEvent.AddListener(SetItemImage);
        eventService.ItemDescriptionEvent.AddListener(SetItemName);
        eventService.ItemDescriptionEvent.AddListener(SetItemDescription);
        eventService.ItemDescriptionPrice.AddListener(SetItemPrice);
        eventService.ChangeButtonText.AddListener(SetQuantitySelectionButtonText);
    }
    private void SetItemImage(ItemSO itemData) => itemImage.sprite = itemData.ItemIcon;
    private void SetItemName(ItemSO itemData) => itemName.text = itemData.ItemName;
    private void SetItemDescription(ItemSO itemData) => itemDescription.text = itemData.ItemDescription;
    private void SetItemPrice(string priceText) => itemPrice.text = priceText;
    private void SetQuantitySelectionButtonText(string text) => quantitySelectionButtonText.text = text;

    private void OnDisable()
    {
        eventService.ItemDescriptionEvent.RemoveListener(SetItemImage);
        eventService.ItemDescriptionEvent.RemoveListener(SetItemName);
        eventService.ItemDescriptionEvent.RemoveListener(SetItemDescription);
        eventService.ItemDescriptionPrice.RemoveListener(SetItemPrice);
        eventService.ChangeButtonText.RemoveListener(SetQuantitySelectionButtonText);
    }
}