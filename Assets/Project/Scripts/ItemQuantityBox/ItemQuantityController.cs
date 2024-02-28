using UnityEngine;

public class ItemQuantityController
{
    private ItemQuantityView itemQuantityView;
    private int currentItemQuantity;
    private int maxItemQuantity;
    private EventService eventService;
    private ItemSO item;
    private bool isSelling;
    public ItemQuantityController(ItemQuantityView itemQuantityView, EventService eventService)
    {
        this.itemQuantityView = itemQuantityView;
        itemQuantityView.SetItemQuantityController(this);
        this.eventService = eventService;
        eventService.OnInventoryItemClickEvent.AddListener(OnInventoryItemClick);
        eventService.OnConfirmButtonClick.AddListener(ItemTransaction);
    }
    private void OnInventoryItemClick(InventoryItemController inventoryItem)
    {
        isSelling = true;
        itemQuantityView.SetItemIcon(inventoryItem.inventoryItemModel.itemData.ItemIcon);
        itemQuantityView.SetItemName(inventoryItem.inventoryItemModel.itemData.ItemName);
        currentItemQuantity = 1;
        itemQuantityView.SetItemQuantity(currentItemQuantity);
        maxItemQuantity = inventoryItem.inventoryItemModel.itemQuantity;
        itemQuantityView.SetConfirmationButtonText("Sell");
        item = inventoryItem.inventoryItemModel.itemData;
    }
    public void OnConfirmationBoxButtonClick()
    {
        if (isSelling)
            eventService.ConfirmationBoxMessage.Invoke(string.Format("Selling {0} {1} for {2} gold.", currentItemQuantity, item.ItemName, (item.ItemSellingPrice * currentItemQuantity)));
        else
            eventService.ConfirmationBoxMessage.Invoke(string.Format("Buying {0} {1} for {2} gold.", currentItemQuantity, item.ItemName, (item.ItemBuyingPrice * currentItemQuantity)));
    }
    public void OnMinusButtonClicked()
    {
        if (currentItemQuantity <= 1) currentItemQuantity = 1;
        else currentItemQuantity--;
        itemQuantityView.SetItemQuantity(currentItemQuantity);
    }
    public void OnPlusButtonClick()
    {
        if (currentItemQuantity >= maxItemQuantity) currentItemQuantity = maxItemQuantity;
        else currentItemQuantity++;
        itemQuantityView.SetItemQuantity(currentItemQuantity);
    }
    private void ItemTransaction()
    {
        if (isSelling)
        {
            eventService.AddMoney.Invoke(item.ItemSellingPrice * currentItemQuantity);
            eventService.RemoveFromInventory.Invoke(item, currentItemQuantity);
        }
    }
    ~ItemQuantityController()
    {
        eventService.OnInventoryItemClickEvent.RemoveListener(OnInventoryItemClick);
        eventService.OnConfirmButtonClick.RemoveListener(ItemTransaction);
    }
}