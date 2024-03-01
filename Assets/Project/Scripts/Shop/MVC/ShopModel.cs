public class ShopModel
{
    public ShopItemView shopItem { get; private set; }
    private ShopController shopController;
    public ShopModel(ShopScriptableObject shopSO, ShopController shopController)
    {
        shopItem = shopSO.shopItem;
        this.shopController = shopController;
    }
}