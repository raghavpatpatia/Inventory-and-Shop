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
        eventService.OnShopItemClickEvent.AddListener(OnShopItemSelected);
    }
    public void OnInventoryItemSelected(InventoryItemController inventoryItem)
    {
        itemDescriptionView.gameObject.SetActive(true);
        itemDescriptionView.SetItemImage(inventoryItem.inventoryItemModel.itemData.ItemIcon);
        itemDescriptionView.SetItemName(inventoryItem.inventoryItemModel.itemData.ItemName);
        itemDescriptionView.SetItemDescription(inventoryItem.inventoryItemModel.itemData.ItemDescription);
        itemDescriptionView.SetItemPrice(string.Format("Selling Price: {0}", inventoryItem.inventoryItemModel.itemData.ItemSellingPrice));
        itemDescriptionView.SetItemWeight(string.Format("Weight: {0}", inventoryItem.inventoryItemModel.itemData.ItemWeight));
        itemDescriptionView.SetQuantitySelectionButtonText("Sell");
    }
    public void OnShopItemSelected(ShopItemController shopItem)
    {
        itemDescriptionView.gameObject.SetActive(true);
        itemDescriptionView.SetItemImage(shopItem.shopItemModel.item.ItemIcon);
        itemDescriptionView.SetItemName(shopItem.shopItemModel.item.ItemName);
        itemDescriptionView.SetItemDescription(shopItem.shopItemModel.item.ItemDescription);
        itemDescriptionView.SetItemPrice(string.Format("Buying Price: {0}", shopItem.shopItemModel.item.ItemBuyingPrice));
        itemDescriptionView.SetItemWeight(string.Format("Weight: {0}", shopItem.shopItemModel.item.ItemWeight));
        itemDescriptionView.SetQuantitySelectionButtonText("Buy");
    }
    ~ItemDescriptionController()
    {
        eventService.OnInventoryItemClickEvent.RemoveListener(OnInventoryItemSelected);
        eventService.OnShopItemClickEvent.RemoveListener(OnShopItemSelected);
    }
}