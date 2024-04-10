public class ShopModel
{
    public ShopItemView ShopItem { get; private set; }
    private ShopController shopController;
    public ShopModel(ShopScriptableObject shopSO, ShopController shopController)
    {
        ShopItem = shopSO.ShopItem;
        this.shopController = shopController;
    }
}