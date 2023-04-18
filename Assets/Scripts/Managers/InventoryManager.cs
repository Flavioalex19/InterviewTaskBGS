using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script made by Flavio Alexandre
/// Script responsible for managing the whole character inventory
/// Adding(and verifying) and removing the items into the grid and from the list of item on the character
/// </summary>

public class InventoryManager : MonoBehaviour
{
    #region Public Variables
    public List<Item> _itemList = new List<Item>();//List of Items on the player
    public GameObject Item_Inventory;//Prefab to be added to the grid
    public float _totalCoins;//Player coins
    public GridLayoutGroup _main_Character_Inventory;//Grid layout for the Inventory
    #endregion

    [SerializeField]GridLayoutGroup _store_gridLayoutGroup;//Grid Layout for the character in the Shop Panel
    [SerializeField] int _currentEquipedItem;

  


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
                newInventoryItem.GetComponent<ItemInventory>().MyItemIndex = _itemList[i].Index;
                //---------------------------------
                newInventoryItem = Instantiate(Item_Inventory);
                newInventoryItem.transform.SetParent(_main_Character_Inventory.transform);
                newInventoryItem.transform.localScale = Vector3.one;
                newInventoryItem.GetComponent<ItemInventory>().SetImage(_itemList[i]);
                newInventoryItem.GetComponent<ItemInventory>().MyItemIndex = _itemList[i].Index;
                //_currentEquipedItem = _itemList[i].Index;
            }
        }
        
    }

    //Create the item on Grid Layout group
    public void AddItem(Item item)
    {
        if (item.MyItemType == ItemType.Outfit) item.IsEquiped = false;
        GameObject newInventoryItem;
        _itemList.Add(item);
        _totalCoins -= item.Cost;
        
        newInventoryItem = Instantiate(Item_Inventory);
        newInventoryItem.transform.SetParent(_store_gridLayoutGroup.transform);//Adding on the grid
        newInventoryItem.transform.localScale = Vector3.one;//Scale of the object on grid
        newInventoryItem.GetComponent<ItemInventory>().SetImage(item);
        newInventoryItem.GetComponent<ItemInventory>().MyItemIndex = item.Index;

        newInventoryItem = Instantiate(Item_Inventory);
        newInventoryItem.transform.SetParent(_main_Character_Inventory.transform);
        newInventoryItem.transform.localScale = Vector3.one;
        newInventoryItem.GetComponent<ItemInventory>().SetImage(item);
        newInventoryItem.GetComponent<ItemInventory>().MyItemIndex = item.Index;
        

    }

   
    public void RemoveFromInventory(int index)
    {
        for (int i = 0; i < _itemList.Count; i++)
        {
            if (_itemList[i].Index == index)
            {
                _itemList[i].IsEquiped = false;
                _itemList.Remove(_itemList[i]);
            }
        }
       
    }
    //Verify if the item already exists
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

    public void SellItem(GameObject ThisgameObject)
    {
        //_main_Character_Inventory.transform.SetParent(null);
        ThisgameObject.transform.SetParent(null);
        Destroy(ThisgameObject.GetComponent<ItemInventory>());
    }
    
}
