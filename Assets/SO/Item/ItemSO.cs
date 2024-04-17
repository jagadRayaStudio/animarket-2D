using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ProductCategory { Sayur, Buah, Ikan }

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public int cost;
    public Sprite sprite;
    public string itemDesc;

    public ProductCategory category;
}
