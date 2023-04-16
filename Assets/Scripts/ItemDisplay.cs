using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Script Made by Flavio Alexandre
/// This Script is responsible for the item being sold on the shop
/// </summary>
public class ItemDisplay : MonoBehaviour
{

    public Item _item;
    [SerializeField] PlayerManager _playerManager;
    [SerializeField] InventoryManager _inventoryManager;

    //UI
    [Header("UI Elements")]
    [SerializeField] Image _item_Image;
    [SerializeField] Button _item_Button;

    //variables
    public int Amount;

    // Start is called before the first frame update
    void Start()
    {
        _item_Button.onClick.AddListener(AddItemToPlayerInventory);
        //_item_Image = GetComponent<Image>();
        _item_Image.sprite = _item.ItemSprite;
    }

    void AddItemToPlayerInventory()
    {
        if (_inventoryManager.CheckIfItemIsOntheList(_item))
        {
            if (Amount > 0)
            {
                Amount--;//Protection to not go negative
            }
        }
        else
        {
            if (Amount > 0)
            {
                Amount--;//Protection to not go negative
                _inventoryManager.AddItem(_item);
            }
            
        }
        /*
        //_playerManager._itemList.Add(this.gameObject);
        if (_item.MyItemType == ItemType.Consumable)
        {
            if (_inventoryManager.CheckIfItemIsOntheList(_item))
            {
                if (Amount > 0)
                {
                    Amount--;//Protection to not go negative
                }
            }
            else
            {
                _inventoryManager.AddItem(_item);
            }
        }
        */

    }
}
