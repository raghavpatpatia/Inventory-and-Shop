using UnityEditor.MPE;

public class InventoryItemController
{
    public InventoryItemModel inventoryItemModel { get; private set; }
    private InventoryItemView inventoryItemView;
    private EventService eventService;
    public InventoryItemController(ItemSO item, InventoryItemView inventoryItemView, EventService eventService)
    {
        this.inventoryItemModel = new InventoryItemModel(item, this);
        this.inventoryItemView = inventoryItemView;
        inventoryItemView.SetInventoryItemController(this);
        inventoryItemView.SetItemIcon(inventoryItemModel.itemData.ItemIcon);
        this.eventService = eventService;
    }

    public void IncreaseQuantity(int amount)
    {
        if (inventoryItemView.gameObject.activeSelf == false)
            inventoryItemView.gameObject.SetActive(true);
        inventoryItemModel.IncreaseItemQuantity(amount);
        inventoryItemView.UpdateItemQuantity(inventoryItemModel.itemQuantity);
    }

    public void DecreaseQuantity(int amount)
    {
        if (inventoryItemModel.itemQuantity - amount <= 0)
        {
            inventoryItemView.gameObject.SetActive(false);
            inventoryItemModel.itemQuantity = 0;
            inventoryItemView.UpdateItemQuantity(inventoryItemModel.itemQuantity);
        }
        else
        {
            inventoryItemModel.DecreaseItemQuantity(amount);
            inventoryItemView.UpdateItemQuantity(inventoryItemModel.itemQuantity);
        }
    }
    public void OnInventoryItemClick() => eventService.OnInventoryItemClickEvent.Invoke(this);
}