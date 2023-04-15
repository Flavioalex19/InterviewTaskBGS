using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Script made by Flavio Alexandre
/// Script responsible for managing the character inventory
/// </summary>

public class InventoryManager : MonoBehaviour
{
    public List<Item> _itemList = new List<Item>();//List for Items
    public GameObject Item_Inventory;

    [SerializeField]GridLayoutGroup _gridLayoutGroup;


    private void Update()
    {
        
    }

    public void AddItem(Item item)
    {
        GameObject newInventoryItem;
        _itemList.Add(item);
        newInventoryItem = Instantiate(Item_Inventory);
        newInventoryItem.transform.SetParent(_gridLayoutGroup.transform);
        newInventoryItem.transform.localScale = Vector3.one;
        newInventoryItem.GetComponent<ItemInventory>().SetImage(item);

        
    }
    public void RemoveItem(Item item)
    {
        _itemList.Remove(item);
    }

    public bool CheckIfItemIsOntheList(Item item)
    {
        bool isOnTheList = false;
        for (int i = 0; i < _itemList.Count; i++)
        {
            if (item.ItemName == _itemList[i].ItemName)
            {
                isOnTheList = true;
                return true;

            }
            else
            {
                isOnTheList = false;


            }
        }
        return isOnTheList;
    }
}
