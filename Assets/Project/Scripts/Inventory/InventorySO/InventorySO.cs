using UnityEngine;

[CreateAssetMenu (fileName = "Inventory", menuName = "ScriptableObjects/Inventory/Inventory")]
public class InventorySO : ScriptableObject
{
    public float InventoryWeight;
    public InventoryItemView InventoryItemView;
}