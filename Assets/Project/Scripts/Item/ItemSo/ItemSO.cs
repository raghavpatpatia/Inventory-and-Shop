using UnityEngine;

[CreateAssetMenu(fileName = "ItemSOList", menuName = "ScriptableObjects/Item/ItemSOList")]
public class ItemSOList : ScriptableObject
{
    public ItemSOList[] items;
}

[CreateAssetMenu(fileName = "ItemSO", menuName = "ScriptableObjects/Item/ItemSO")]
public class ItemSO : ScriptableObject
{
    public ItemType itemType;
    public Sprite ItemIcon;
    public string ItemName;
    [TextArea] public string ItemDescription;
    public int ItemBuyingPrice;
    public int ItemSellingPrice;
    public float ItemWeight;
    public ItemRarity itemRarity;
}
