using System.Collections.Generic;
using UnityEngine;

public class GatherButtonEvent
{
    private ItemSOList itemList;
    private EventService eventService;
    private ItemRarity itemRarity;
    private List<ItemSO> filteredItems;
    public GatherButtonEvent(ItemSOList itemList, EventService eventService, ItemRarity itemRarity)
    {
        this.itemList = itemList;
        this.eventService = eventService;
        this.itemRarity = itemRarity;
        filteredItems = new List<ItemSO>();
        AddItemsToFilteredList();
    }

    public void GatherItem()
    {
        ItemSO item = GenerateRandomItem();
        eventService.AddToInventory.Invoke(item, 1);
    }

    private ItemSO GenerateRandomItem()
    {
        ItemSO randomItem = filteredItems[Random.Range(0, filteredItems.Count)];
        return randomItem;
    }
    private void AddItemsToFilteredList()
    {
        foreach (ItemSO item in itemList.items)
        {
            if (item.itemRarity == itemRarity)
                filteredItems.Add(item);
        }
    }
}