using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Script Made by Flavio Alexandre
/// This Script is responsible for the item that is being sold on the shop
/// The script manage the addition of item into the player inventory , verifying what kind of item is and if it is possible to add into the inventory 
/// </summary>
public class ItemDisplay : MonoBehaviour
{
    #region Publib Variables
    public Item _item;//The item tha will be sold
    //variables
    public int Amount;//Amount of the item to sell
    #endregion
    #region Private Variables
    [SerializeField] InventoryManager _inventoryManager;//reference of the inventory manager
    //UI
    [Header("UI Elements")]
    [SerializeField] Image _item_Image;
    [SerializeField] Button _item_Button;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        _inventoryManager = GameObject.Find("Inventory Manager").GetComponent<InventoryManager>();

        _item_Button.onClick.AddListener(AddItemToPlayerInventory);//Sell Button
        _item_Image.sprite = _item.ItemSprite;//Change for the correspondent item sprite
    }
    //Add item into the inventory
    void AddItemToPlayerInventory()
    {
        //Check if the item is already in the inventory
        if (_inventoryManager.CheckIfItemIsOntheList(_item))
        {
            /*
            if (Amount > 0)
            {
                Amount--;//Protection to not go negative
            }
            */
            return;
        }
        else
        {
            //Verify if the item is avaliable in the shop
            if (Amount > 0 && !_inventoryManager.CheckIfItemIsOntheList(_item))
            {
                //Amount--;//Protection to not go negative
                _inventoryManager.AddItem(_item);//Add Item
            }
            
            //Amount--;//Protection to not go negative
            //_inventoryManager.AddItem(_item);

        }

    }
}
