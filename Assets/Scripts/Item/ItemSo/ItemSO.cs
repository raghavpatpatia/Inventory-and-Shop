using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ScriptableObjects/Item/ItemSO")]
public class ItemSO : ScriptableObject
{
    public ItemType ItemType;
    public Sprite ItemIcon;
    public string ItemName;
    [TextArea] public string ItemDescription;
    public int ItemBuyingPrice;
    public int ItemSellingPrice;
    public float ItemWeight;
    public ItemRarity ItemRarity;
}
