public class ItemDescriptionController
{
    private ItemDescriptionView itemDescriptionView;
    private EventService eventService;
    public ItemDescriptionController(ItemDescriptionView itemDescriptionView, EventService eventService)
    {
        this.itemDescriptionView = itemDescriptionView;
        itemDescriptionView.SetItemDescriptionController(this);
        this.eventService = eventService;
        eventService.OnInventoryItemClickEvent.AddListener(OnInventoryItemSelected);
    }
    public void OnInventoryItemSelected(InventoryItemController inventoryItem)
    {
        itemDescriptionView.gameObject.SetActive(true);
        itemDescriptionView.SetItemImage(inventoryItem.inventoryItemModel.itemData.ItemIcon);
        itemDescriptionView.SetItemName(inventoryItem.inventoryItemModel.itemData.ItemName);
        itemDescriptionView.SetItemDescription(inventoryItem.inventoryItemModel.itemData.ItemDescription);
        itemDescriptionView.SetItemPrice(string.Format("Selling Price: {0}", inventoryItem.inventoryItemModel.itemData.ItemSellingPrice));
        itemDescriptionView.SetQuantitySelectionButtonText("Sell");
    }
    ~ItemDescriptionController()
    {
        eventService.OnInventoryItemClickEvent.RemoveListener(OnInventoryItemSelected);
    }
}