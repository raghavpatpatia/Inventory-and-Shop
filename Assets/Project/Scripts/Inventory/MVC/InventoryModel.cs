public class InventoryModel
{
    private InventoryController inventoryController;
    public InventoryItemView inventoryItem { get; private set; }
    public float inventoryWeight { get; private set; }
    public float inventoryMaxWeight {  get; private set; }
    public InventoryModel(InventorySO inventorySO, InventoryController inventoryController)
    {
        this.inventoryController = inventoryController;
        this.inventoryItem = inventorySO.inventoryItemView;
        this.inventoryMaxWeight = inventorySO.inventoryWeight;
        inventoryWeight = 0;
    }
    public void IncreaseInventoryWeight(float amount) => inventoryWeight += amount;
    public void DecreaseInventoryWeight(float amount) => inventoryWeight -= amount;
}