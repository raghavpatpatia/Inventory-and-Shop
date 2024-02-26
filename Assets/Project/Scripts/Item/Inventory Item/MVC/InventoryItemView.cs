using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItemView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemQuantityText;
    private InventoryItemController inventoryItemController;
    public void SetInventoryItemController(InventoryItemController inventoryItemController) => this.inventoryItemController = inventoryItemController;
    public void SetItemIcon(Sprite itemIcon) => this.itemIcon.sprite = itemIcon;
    public void UpdateItemQuantity(int amount) => itemQuantityText.text = amount.ToString();
    public void OnPointerClick(PointerEventData eventData) => inventoryItemController.OnInventoryItemClick();
}