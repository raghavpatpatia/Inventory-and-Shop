public class ItemDescriptionController
{
    private ItemDescriptionView itemDescriptionView;
    private ItemSO item;
    private EventService eventService;
    public ItemDescriptionController(ItemSO item, ItemDescriptionView itemDescriptionView, EventService eventService)
    {
        this.eventService = eventService;
        this.item = item;
        this.itemDescriptionView = itemDescriptionView;
        itemDescriptionView.SetItemDescriptionController(this);
        itemDescriptionView.SetEventService(eventService);
        itemDescriptionView.SetItemIcon(item.ItemIcon);
        itemDescriptionView.SetItemName(item.ItemName);
        itemDescriptionView.SetItemDescription(item.ItemDescription);
    }
}