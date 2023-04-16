using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Consumable,
    Outfit
}

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public string ItemName;
    public string Description;
    public ItemType MyItemType;

    public float Cost;

    public int Index;
    
    public bool IsEquiped = false;

    public Sprite ItemSprite;//Sprit to show on the inventory or shop
    
}
