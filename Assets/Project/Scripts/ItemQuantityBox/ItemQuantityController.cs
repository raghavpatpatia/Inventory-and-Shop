using UnityEngine;

public class ItemQuantityController
{
    private ItemQuantityView itemQuantityView;
    private int currentItemQuantity;
    private int maxItemQuantity;
    private EventService eventService;
    private MoneyController moneyController;
    private ItemSO item;
    private bool isSelling;
    public ItemQuantityController(ItemQuantityView itemQuantityView, EventService eventService, MoneyController moneyController)
    {
        this.itemQuantityView = itemQuantityView;
        itemQuantityView.SetItemQuantityController(this);
        this.eventService = eventService;
        this.moneyController = moneyController;
        eventService.OnShopItemClickEvent.AddListener(OnShopItemClick);
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
    private void OnShopItemClick(ShopItemController shopItem)
    {
        isSelling = false;
        itemQuantityView.SetItemIcon(shopItem.shopItemModel.item.ItemIcon);
        itemQuantityView.SetItemName(shopItem.shopItemModel.item.ItemName);
        currentItemQuantity = 1;
        itemQuantityView.SetItemQuantity(currentItemQuantity);
        maxItemQuantity = int.MaxValue;
        itemQuantityView.SetConfirmationButtonText("Buy");
        item = shopItem.shopItemModel.item;
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
            moneyController.AddMoney(item.ItemSellingPrice * currentItemQuantity);
            eventService.RemoveFromInventory.Invoke(item, currentItemQuantity);
        }
        else if (!isSelling)
        {
            if (moneyController.currentMoney >= item.ItemBuyingPrice * currentItemQuantity)
            {
                moneyController.SubtractMoney(item.ItemBuyingPrice * currentItemQuantity);
                eventService.AddToInventory.Invoke(item, currentItemQuantity);
            }
            else
            {
                eventService.DisplayMessage.Invoke("Not enough money.");
            }
        }
    }
    ~ItemQuantityController()
    {
        eventService.OnShopItemClickEvent.RemoveListener(OnShopItemClick);
        eventService.OnInventoryItemClickEvent.RemoveListener(OnInventoryItemClick);
        eventService.OnConfirmButtonClick.RemoveListener(ItemTransaction);
    }
}