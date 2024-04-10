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
    private SoundController soundController;
    public ItemQuantityController(ItemQuantityView itemQuantityView, EventService eventService, MoneyController moneyController, SoundController soundController)
    {
        this.itemQuantityView = itemQuantityView;
        itemQuantityView.SetItemQuantityController(this);
        this.eventService = eventService;
        this.moneyController = moneyController;
        eventService.OnShopItemClickEvent.AddListener(OnShopItemClick);
        eventService.OnInventoryItemClickEvent.AddListener(OnInventoryItemClick);
        eventService.OnConfirmButtonClick.AddListener(ItemTransaction);
        this.soundController = soundController;
    }
    private void OnInventoryItemClick(InventoryItemController inventoryItem)
    {
        isSelling = true;
        itemQuantityView.SetItemIcon(inventoryItem.InventoryItemModel.ItemData.ItemIcon);
        itemQuantityView.SetItemName(inventoryItem.InventoryItemModel.ItemData.ItemName);
        currentItemQuantity = 1;
        itemQuantityView.SetItemQuantity(currentItemQuantity);
        maxItemQuantity = inventoryItem.InventoryItemModel.ItemQuantity;
        itemQuantityView.SetConfirmationButtonText("Sell");
        item = inventoryItem.InventoryItemModel.ItemData;
    }
    private void OnShopItemClick(ShopItemController shopItem)
    {
        isSelling = false;
        itemQuantityView.SetItemIcon(shopItem.ShopItemModel.Item.ItemIcon);
        itemQuantityView.SetItemName(shopItem.ShopItemModel.Item.ItemName);
        currentItemQuantity = 1;
        itemQuantityView.SetItemQuantity(currentItemQuantity);
        maxItemQuantity = int.MaxValue;
        itemQuantityView.SetConfirmationButtonText("Buy");
        item = shopItem.ShopItemModel.Item;
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
            soundController.PlayMusic(Sounds.SUCCESSFULITEMSELLING);
        }
        else if (!isSelling)
        {
            if (moneyController.CurrentMoney >= item.ItemBuyingPrice * currentItemQuantity)
            {
                moneyController.SubtractMoney(item.ItemBuyingPrice * currentItemQuantity);
                eventService.AddToInventory.Invoke(item, currentItemQuantity);
                soundController.PlayMusic(Sounds.SUCCESSFULITEMBUYING);
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