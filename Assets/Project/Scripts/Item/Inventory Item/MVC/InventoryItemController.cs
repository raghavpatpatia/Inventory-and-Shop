public class InventoryItemController
{
    public InventoryItemModel InventoryItemModel { get; private set; }
    private InventoryItemView inventoryItemView;
    private EventService eventService;
    public InventoryItemController(ItemSO item, InventoryItemView inventoryItemView, EventService eventService)
    {
        this.InventoryItemModel = new InventoryItemModel(item, this);
        this.inventoryItemView = inventoryItemView;
        inventoryItemView.SetInventoryItemController(this);
        inventoryItemView.SetItemIcon(InventoryItemModel.ItemData.ItemIcon);
        this.eventService = eventService;
    }

    public void IncreaseQuantity(int amount)
    {
        if (inventoryItemView.gameObject.activeSelf == false)
            inventoryItemView.gameObject.SetActive(true);
        InventoryItemModel.IncreaseItemQuantity(amount);
        inventoryItemView.UpdateItemQuantity(InventoryItemModel.ItemQuantity);
    }

    public void DecreaseQuantity(int amount)
    {
        if (InventoryItemModel.ItemQuantity - amount <= 0)
        {
            inventoryItemView.gameObject.SetActive(false);
            InventoryItemModel.ItemQuantity = 0;
            inventoryItemView.UpdateItemQuantity(InventoryItemModel.ItemQuantity);
        }
        else
        {
            InventoryItemModel.DecreaseItemQuantity(amount);
            inventoryItemView.UpdateItemQuantity(InventoryItemModel.ItemQuantity);
        }
    }
    public void OnInventoryItemClick() => eventService.OnInventoryItemClickEvent.Invoke(this);
}