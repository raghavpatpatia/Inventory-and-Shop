public class ShopItemModel
{
    private ShopItemController shopItemController;
    public ItemSO Item { get; private set; }
    public ShopItemModel(ShopItemController shopItemController, ItemSO item)
    {
        this.shopItemController = shopItemController;
        this.Item = item;
    }
}