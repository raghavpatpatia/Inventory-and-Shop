public class EventService
{
    public EventController<ItemSO, int> AddToInventory;
    public EventService()
    {
        AddToInventory = new EventController<ItemSO, int>();
    }
}