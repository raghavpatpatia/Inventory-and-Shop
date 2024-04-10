public class InventoryModel
{
    private InventoryController inventoryController;
    public InventoryItemView InventoryItem { get; private set; }
    public float InventoryWeight { get; private set; }
    public float InventoryMaxWeight {  get; private set; }
    public InventoryModel(InventorySO inventorySO, InventoryController inventoryController)
    {
        this.inventoryController = inventoryController;
        this.InventoryItem = inventorySO.InventoryItemView;
        this.InventoryMaxWeight = inventorySO.InventoryWeight;
        InventoryWeight = 0;
    }
    public void IncreaseInventoryWeight(float amount) => InventoryWeight += amount;
    public void DecreaseInventoryWeight(float amount) => InventoryWeight -= amount;
}