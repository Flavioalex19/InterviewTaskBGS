using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;
/// <summary>
/// Script made by Flavio Alexandre
/// Script responsible for managing the character inventory
/// </summary>

public class InventoryManager : MonoBehaviour
{
    public List<Item> _itemList = new List<Item>();//List for Items
    public GameObject Item_Inventory;//Prefab to be added to the grid

    [SerializeField]public GridLayoutGroup _main_Character_Inventory;//Grid layout for the Inventory
    [SerializeField]GridLayoutGroup _store_gridLayoutGroup;//Grid Layout for the character in the Shop Panel

    [SerializeField] int _currentEquipedItem;
    public float _totalCoins;


    private void Awake()
    {
        //Verify if in the start of the game there is any items on the inventory list and update the ui(equipemt UI and Store UI)
        if (_itemList.Count > 0)
        {
            for (int i = 0; i < _itemList.Count; i++)
            {
                GameObject newInventoryItem;
                newInventoryItem = Instantiate(Item_Inventory);
                newInventoryItem.transform.SetParent(_store_gridLayoutGroup.transform);//Add into the store UI for the player
                newInventoryItem.transform.localScale = Vector3.one;
                newInventoryItem.GetComponent<ItemInventory>().SetImage(_itemList[i]);
                newInventoryItem.GetComponent<ItemInventory>().MyItemIndex = /*_itemList[i].Index*/ i;
                //---------------------------------
                newInventoryItem = Instantiate(Item_Inventory);
                newInventoryItem.transform.SetParent(_main_Character_Inventory.transform);
                newInventoryItem.transform.localScale = Vector3.one;
                newInventoryItem.GetComponent<ItemInventory>().SetImage(_itemList[i]);
                newInventoryItem.GetComponent<ItemInventory>().MyItemIndex = /*_itemList[i].Index*/ i;
                //_currentEquipedItem = _itemList[i].Index;
            }
        }
        
    }


    public void AddItem(Item item)
    {
        if (item.MyItemType == ItemType.Outfit) item.IsEquiped = false;
        GameObject newInventoryItem;
        _itemList.Add(item);
        _totalCoins -= item.Cost;
        newInventoryItem = Instantiate(Item_Inventory);
        newInventoryItem.transform.SetParent(_store_gridLayoutGroup.transform);
        newInventoryItem.transform.localScale = Vector3.one;
        newInventoryItem.GetComponent<ItemInventory>().SetImage(item);
        newInventoryItem.GetComponent<ItemInventory>().MyItemIndex = /*item.Index*/_itemList.Count -1;

        newInventoryItem = Instantiate(Item_Inventory);
        newInventoryItem.transform.SetParent(_main_Character_Inventory.transform);
        newInventoryItem.transform.localScale = Vector3.one;
        newInventoryItem.GetComponent<ItemInventory>().SetImage(item);
        newInventoryItem.GetComponent<ItemInventory>().MyItemIndex = /*item.Index*/_itemList.Count -1;


    }
    public void RemoveFromInventory(int index)
    {
        for (int i = 0; i < _itemList.Count; i++)
        {
            if (_itemList[i].Index == index)
            {
                _itemList.Remove(_itemList[i]);
            }
        }
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
