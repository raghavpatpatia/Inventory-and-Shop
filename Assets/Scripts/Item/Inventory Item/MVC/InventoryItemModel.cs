public class InventoryItemModel
{
    private InventoryItemController inventoryItemController;
    public int ItemQuantity;
    public ItemSO ItemData { get; private set; }
    public InventoryItemModel(ItemSO itemData, InventoryItemController inventoryItemController)
    {
        this.inventoryItemController = inventoryItemController;
        this.ItemData = itemData;
        ItemQuantity = 0;
    }
    public void IncreaseItemQuantity(int amount) => ItemQuantity += amount;
    public void DecreaseItemQuantity(int amount) => ItemQuantity -= amount;
}