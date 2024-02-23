public class InventoryItemModel
{
    private InventoryItemController inventoryItemController;
    public int itemQuantity { get; private set; }
    public ItemSO itemData { get; private set; }
    public InventoryItemModel(ItemSO itemData, InventoryItemController inventoryItemController)
    {
        this.inventoryItemController = inventoryItemController;
        this.itemData = itemData;
        itemQuantity = 0;
    }
    public void IncreaseItemQuantity(int amount) => itemQuantity += amount;
    public void DecreaseItemQuantity(int amount) => itemQuantity -= amount;
}