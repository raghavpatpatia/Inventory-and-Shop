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
        itemDescriptionView.SetItemImage(inventoryItem.InventoryItemModel.ItemData.ItemIcon);
        itemDescriptionView.SetItemName(inventoryItem.InventoryItemModel.ItemData.ItemName);
        itemDescriptionView.SetItemDescription(inventoryItem.InventoryItemModel.ItemData.ItemDescription);
        itemDescriptionView.SetItemPrice(string.Format("Selling Price: {0}", inventoryItem.InventoryItemModel.ItemData.ItemSellingPrice));
        itemDescriptionView.SetItemWeight(string.Format("Weight: {0}", inventoryItem.InventoryItemModel.ItemData.ItemWeight));
        itemDescriptionView.SetQuantitySelectionButtonText("Sell");
    }
    public void OnShopItemSelected(ShopItemController shopItem)
    {
        itemDescriptionView.gameObject.SetActive(true);
        itemDescriptionView.SetItemImage(shopItem.ShopItemModel.Item.ItemIcon);
        itemDescriptionView.SetItemName(shopItem.ShopItemModel.Item.ItemName);
        itemDescriptionView.SetItemDescription(shopItem.ShopItemModel.Item.ItemDescription);
        itemDescriptionView.SetItemPrice(string.Format("Buying Price: {0}", shopItem.ShopItemModel.Item.ItemBuyingPrice));
        itemDescriptionView.SetItemWeight(string.Format("Weight: {0}", shopItem.ShopItemModel.Item.ItemWeight));
        itemDescriptionView.SetQuantitySelectionButtonText("Buy");
    }
    ~ItemDescriptionController()
    {
        eventService.OnInventoryItemClickEvent.RemoveListener(OnInventoryItemSelected);
        eventService.OnShopItemClickEvent.RemoveListener(OnShopItemSelected);
    }
}