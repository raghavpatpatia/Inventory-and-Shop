using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItemView : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemQuantityText;
    private InventoryItemController inventoryItemController;
    private EventService eventService;
    public void SetInventoryItemController(InventoryItemController inventoryItemController) => this.inventoryItemController = inventoryItemController;
    public void SetEventService(EventService eventService) => this.eventService = eventService;
    public void SetItemIcon(Sprite itemIcon) => this.itemIcon.sprite = itemIcon;
    public void UpdateItemQuantity(int amount) => itemQuantityText.text = amount.ToString();
}