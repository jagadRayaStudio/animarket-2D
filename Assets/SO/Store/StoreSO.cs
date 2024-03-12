using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Store", menuName = "Store")]

public class StoreSO : ScriptableObject
{
    public string storeName;
    public List<ItemSO> storeItems;
}