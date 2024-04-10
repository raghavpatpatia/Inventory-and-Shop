using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSOList", menuName = "ScriptableObjects/Item/ItemSOList")]
public class ItemSOList : ScriptableObject
{
    public List<ItemSO> Items;
}