public class ShopItemModel
{
    private ShopItemController shopItemController;
    public ItemSO item { get; private set; }
    public ShopItemModel(ShopItemController shopItemController, ItemSO item)
    {
        this.shopItemController = shopItemController;
        this.item = item;
    }
}