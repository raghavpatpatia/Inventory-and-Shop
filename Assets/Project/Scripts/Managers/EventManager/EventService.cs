public class EventService
{
    public EventController<ItemSO, int> AddToInventory;
    public EventController<ItemSO> ItemDescriptionEvent;
    public EventController<string> ItemDescriptionPrice;
    public EventController<string> ChangeButtonText;
    public EventController OnInventoryItemClickEvent;
    public EventService()
    {
        AddToInventory = new EventController<ItemSO, int>();
        ItemDescriptionEvent = new EventController<ItemSO>();
        ItemDescriptionPrice = new EventController<string>();
        ChangeButtonText = new EventController<string>();
        OnInventoryItemClickEvent = new EventController();
    }
}