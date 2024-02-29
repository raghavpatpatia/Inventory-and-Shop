public class EventService
{
    public EventController<ItemSO, int> AddToInventory;
    public EventController<ItemSO, int> RemoveFromInventory;
    public EventController<InventoryItemController> OnInventoryItemClickEvent;
    public EventController<ShopItemController> OnShopItemClickEvent;
    public EventController<int> AddMoney;
    public EventController<int> SubtractMoney;
    public EventController<string> ConfirmationBoxMessage;
    public EventController OnConfirmButtonClick;
    public EventService()
    {
        AddToInventory = new EventController<ItemSO, int>();
        RemoveFromInventory = new EventController<ItemSO, int>();
        OnInventoryItemClickEvent = new EventController<InventoryItemController>();
        OnShopItemClickEvent = new EventController<ShopItemController>();
        AddMoney = new EventController<int>();
        SubtractMoney = new EventController<int>();
        ConfirmationBoxMessage = new EventController<string>();
        OnConfirmButtonClick = new EventController();
    }
}