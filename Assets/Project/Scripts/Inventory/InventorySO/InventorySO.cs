using UnityEngine;

[CreateAssetMenu (fileName = "Inventory", menuName = "ScriptableObjects/Inventory/Inventory")]
public class InventorySO : ScriptableObject
{
    public float inventoryWeight;
    public InventoryItemView inventoryItemView;
}