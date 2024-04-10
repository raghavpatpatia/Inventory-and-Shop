public class ShopItemController
{
    public ShopItemModel ShopItemModel { get; private set; }
    private ShopItemView shopItemView;
    private EventService eventService;
    public ShopItemController(ItemSO item, ShopItemView shopItemView, EventService eventService)
    {
        this.eventService = eventService;
        ShopItemModel = new ShopItemModel(this, item);
        this.shopItemView = shopItemView;
        shopItemView.SetShopItemController(this);
        shopItemView.SetItemIcon(ShopItemModel.Item.ItemIcon);
        shopItemView.SetItemName(ShopItemModel.Item.ItemName);
    }
    public void OnShopItemClick() => eventService.OnShopItemClickEvent.Invoke(this);
}