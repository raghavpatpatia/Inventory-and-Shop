﻿using System.Collections.Generic;
using UnityEngine;

public class InventoryController
{
    private InventoryModel inventoryModel;
    private InventoryView inventoryView;
    private EventService eventService;
    private List<InventoryItemController> inventoryItemList;
    public InventoryController(InventorySO inventorySO, InventoryView inventoryView, EventService eventService)
    {
        this.eventService = eventService;
        this.inventoryModel = new InventoryModel(inventorySO, this);
        this.inventoryView = inventoryView;
        inventoryView.SetInventoryController(this);
        inventoryItemList = new List<InventoryItemController>();
        eventService.AddToInventory.AddListener(AddToInventory);
        eventService.RemoveFromInventory.AddListener(RemoveFromInventory);
    }
    public float GetInventoryWeight() => inventoryModel.inventoryWeight;
    public float GetInventoryMaxWeight() => inventoryModel.inventoryMaxWeight;
    private void AddToInventory(ItemSO item, int quantity)
    {
        if (item.ItemWeight * quantity < GetInventoryMaxWeight() && item.ItemWeight * quantity + GetInventoryWeight() < GetInventoryMaxWeight())
        {
            InventoryItemController existingItem = inventoryItemList.Find(inventoryItem => inventoryItem.inventoryItemModel.itemData.ItemName == item.ItemName);
            if (existingItem != null)
            {
                existingItem.IncreaseQuantity(quantity);
                inventoryModel.IncreaseInventoryWeight(existingItem.inventoryItemModel.itemData.ItemWeight * quantity);
                inventoryView.SetInventoryWeightText();
            }
            else
                CreateNewItem(item, quantity);
        }
        else
            eventService.DisplayMessage.Invoke("Cannot add items to inventory.");
    }
    private void RemoveFromInventory(ItemSO item, int quantity)
    {
        InventoryItemController existingItem = inventoryItemList.Find(inventoryItem => inventoryItem.inventoryItemModel.itemData.ItemName == item.ItemName);
        if (existingItem != null && quantity > 0)
        {
            existingItem.DecreaseQuantity(quantity);
            inventoryModel.DecreaseInventoryWeight(existingItem.inventoryItemModel.itemData.ItemWeight * quantity);
            inventoryView.SetInventoryWeightText();
        }
        else
        {
            eventService.DisplayMessage.Invoke("No such item in inventory.");
        }
    }
    private void CreateNewItem(ItemSO item, int quantity)
    {
        InventoryItemView itemView = GameObject.Instantiate<InventoryItemView>(inventoryModel.inventoryItem, inventoryView.contentArea.transform);
        InventoryItemController newItem = new InventoryItemController(item, itemView, eventService);
        newItem.IncreaseQuantity(quantity);
        inventoryModel.IncreaseInventoryWeight(newItem.inventoryItemModel.itemData.ItemWeight * quantity);
        inventoryView.SetInventoryWeightText();
        inventoryItemList.Add(newItem);
    }

    ~InventoryController()
    {
        if (eventService != null)
        {
            eventService.AddToInventory.RemoveListener(AddToInventory);
            eventService.RemoveFromInventory.RemoveListener(RemoveFromInventory);
        }
    }

}