public class EventService
{
    public EventController<ItemSO, int> AddToInventory;
    public EventController<ItemSO, int> RemoveFromInventory;
    public EventController<InventoryItemController> OnInventoryItemClickEvent;
    public EventController<ShopItemController> OnShopItemClickEvent;
    public EventController<string> ConfirmationBoxMessage;
    public EventController<string> DisplayMessage;
    public EventController OnConfirmButtonClick;
    public EventService()
    {
        AddToInventory = new EventController<ItemSO, int>();
        RemoveFromInventory = new EventController<ItemSO, int>();
        OnInventoryItemClickEvent = new EventController<InventoryItemController>();
        OnShopItemClickEvent = new EventController<ShopItemController>();
        ConfirmationBoxMessage = new EventController<string>();
        DisplayMessage = new EventController<string>();
        OnConfirmButtonClick = new EventController();
    }
}