public class EventService
{
    public EventController OnInventoryItemClickEvent;
    public EventController<string> ItemDescriptionBoxItemPriceText;
    public EventController<string> ItemDescriptionBoxButtonText;
    public EventService()
    {
        OnInventoryItemClickEvent = new EventController();
        ItemDescriptionBoxItemPriceText = new EventController<string>();
        ItemDescriptionBoxButtonText = new EventController<string>();
    }
}