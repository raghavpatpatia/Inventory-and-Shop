using UnityEngine;

[CreateAssetMenu (fileName = "Inventory", menuName = "ScriptableObjects/Inventory/Inventory")]
public class InventorySO : ScriptableObject
{
    public int inventoryWeight;
    public InventoryItemView inventoryItemView;
}