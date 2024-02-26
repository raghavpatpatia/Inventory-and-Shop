public class EventService
{
    public EventController<ItemSO, int> AddToInventory;
    public EventController<InventoryItemController> OnInventoryItemClickEvent;
    public EventService()
    {
        AddToInventory = new EventController<ItemSO, int>();
        OnInventoryItemClickEvent = new EventController<InventoryItemController>();
    }
}