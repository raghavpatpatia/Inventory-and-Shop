using System.Collections.Generic;
using UnityEngine;

public class GatherButtonEvent
{
    private ItemSOList itemList;
    private EventService eventService;
    private ItemRarity itemRarity;
    private SoundController soundController;
    private List<ItemSO> filteredItems;
    public GatherButtonEvent(ItemSOList itemList, EventService eventService, ItemRarity itemRarity, SoundController soundController)
    {
        this.itemList = itemList;
        this.eventService = eventService;
        this.itemRarity = itemRarity;
        filteredItems = new List<ItemSO>();
        AddItemsToFilteredList();
        this.soundController = soundController;
    }

    public void GatherItem()
    {
        ItemSO item = GenerateRandomItem();
        eventService.AddToInventory.Invoke(item, 1);
        soundController.PlayMusic(Sounds.GATHERBUTTONCLICK);
    }

    private ItemSO GenerateRandomItem()
    {
        if (filteredItems.Count > 0)
        {
            return filteredItems[Random.Range(0, filteredItems.Count)];
        }
        else
        {
            return null;
        }
    }

    private void AddItemsToFilteredList()
    {
        foreach (ItemSO item in itemList.Items)
        {
            if (item.ItemRarity == itemRarity)
                filteredItems.Add(item);
        }
    }
}