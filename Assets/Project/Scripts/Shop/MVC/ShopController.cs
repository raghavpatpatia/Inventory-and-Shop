﻿using System.Collections.Generic;
using UnityEngine;

public class ShopController
{
    private ShopModel shopModel;
    private ShopView shopView;
    private ItemSOList itemSOList;
    private EventService eventService;
    public ShopController(ItemSOList itemSOList, ShopView shopView, ShopScriptableObject shopSO, EventService eventService)
    {
        this.itemSOList = itemSOList;
        shopModel = new ShopModel(shopSO, this);
        this.shopView = shopView;
        shopView.SetShopController(this);
        this.eventService = eventService;
    }
    public void AddItemToShop(Transform material, Transform armor, Transform weapon, Transform consumable, Transform treasure)
    {
        List<ItemSO> Items = SortItemList();
        foreach(ItemSO item in Items)
        {
            if (item.itemType == ItemType.Material) CreateShopItem(material, item);
            else if (item.itemType == ItemType.Armor) CreateShopItem(armor, item);
            else if (item.itemType == ItemType.Weapon) CreateShopItem(weapon, item);
            else if (item.itemType == ItemType.Consumable) CreateShopItem(consumable, item);
            else if (item.itemType == ItemType.Treasure) CreateShopItem(treasure, item);
        }
    }
    private void CreateShopItem(Transform transform, ItemSO item)
    {
        ShopItemView shopItem = shopModel.shopItem;
        shopItem = GameObject.Instantiate<ShopItemView>(shopItem, transform);
        ShopItemController shopItemController = new ShopItemController(item, shopItem, eventService);
    }
    private List<ItemSO> SortItemList()
    {
        List<ItemSO> veryCommonItemList = new List<ItemSO>();
        List<ItemSO> commonItemList = new List<ItemSO>();
        List<ItemSO> rareItemList = new List<ItemSO>();
        List<ItemSO> epicItemList = new List<ItemSO>();
        List<ItemSO> legendaryItemList = new List<ItemSO>();
        foreach (ItemSO item in itemSOList.items)
        {
            if (item.itemRarity == ItemRarity.VeryCommon) veryCommonItemList.Add(item);
            else if (item.itemRarity == ItemRarity.Common) commonItemList.Add(item);
            else if (item.itemRarity == ItemRarity.Rare) rareItemList.Add(item);
            else if (item.itemRarity == ItemRarity.Epic) epicItemList.Add(item);
            else if (item.itemRarity == ItemRarity.Legendary) legendaryItemList.Add(item);
        }
        veryCommonItemList = SortSingleList(veryCommonItemList);
        commonItemList = SortSingleList(commonItemList);
        rareItemList = SortSingleList(rareItemList);
        epicItemList = SortSingleList(epicItemList);
        legendaryItemList = SortSingleList(legendaryItemList);
        List<ItemSO> sortedList = new List<ItemSO>();
        sortedList.AddRange(veryCommonItemList);
        sortedList.AddRange(commonItemList);
        sortedList.AddRange(rareItemList);
        sortedList.AddRange(epicItemList);
        sortedList.AddRange(legendaryItemList);
        return sortedList;
    }
    private List<ItemSO> SortSingleList(List<ItemSO> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = 0; j < list.Count - 1 - i; j++)
            {
                if (list[j].ItemBuyingPrice > list[j + 1].ItemBuyingPrice)
                {
                    ItemSO temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                }
            }
        }
        return list;
    }
}