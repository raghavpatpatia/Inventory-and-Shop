public class ShopItemController
{
    public ShopItemModel shopItemModel { get; private set; }
    private ShopItemView shopItemView;
    private EventService eventService;
    public ShopItemController(ItemSO item, ShopItemView shopItemView, EventService eventService)
    {
        this.eventService = eventService;
        shopItemModel = new ShopItemModel(this, item);
        this.shopItemView = shopItemView;
        shopItemView.SetShopItemController(this);
        shopItemView.SetItemIcon(shopItemModel.item.ItemIcon);
        shopItemView.SetItemName(shopItemModel.item.ItemName);
    }
    public void OnShopItemClick() => eventService.OnShopItemClickEvent.Invoke(this);
}