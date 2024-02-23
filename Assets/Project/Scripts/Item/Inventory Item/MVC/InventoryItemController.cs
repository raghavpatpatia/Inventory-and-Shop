public class InventoryItemController
{
    private InventoryItemModel inventoryItemModel;
    private InventoryItemView inventoryItemView;
    private ItemSO item;
    private EventService eventService;
    public InventoryItemController(ItemSO item, InventoryItemView inventoryItemView, EventService eventService)
    {
        this.item = item;
        this.eventService = eventService;
        this.inventoryItemModel = new InventoryItemModel(item, this);
        this.inventoryItemView = inventoryItemView;
        inventoryItemView.SetInventoryItemController(this);
        inventoryItemView.SetEventService(eventService);
        inventoryItemView.SetItemIcon(inventoryItemModel.itemData.ItemIcon);
        eventService.OnInventoryItemClickEvent.AddListener(OnInventoryItemClick);
    }

    public void IncreaseQuantity(int amount)
    {
        inventoryItemModel.IncreaseItemQuantity(amount);
        inventoryItemView.UpdateItemQuantity(inventoryItemModel.itemQuantity);
    }

    public void DecreaseQuantity(int amount)
    {
        if (inventoryItemModel.itemQuantity - amount <= 0)
        {
            inventoryItemView.gameObject.SetActive(false);
        }
        else
        {
            inventoryItemModel.DecreaseItemQuantity(amount);
        }
    }

    private void OnInventoryItemClick()
    {
        eventService.ItemDescriptionBoxItemPriceText.Invoke(string.Format("Selling Price: {0}", inventoryItemModel.itemData.ItemSellingPrice));
        eventService.ItemDescriptionBoxButtonText.Invoke("Sell");
    }

    ~InventoryItemController() => eventService.OnInventoryItemClickEvent.RemoveListener(OnInventoryItemClick);
}