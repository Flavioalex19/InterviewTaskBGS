using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        //_playerManager._itemList.Add(this.gameObject);
        if (_item.MyItemType == ItemType.Consumable)
        {
            /*
            if (_playerManager.CheckIfItemIsOntheList(_item))
            {
                
                if (Amount > 0)
                {
                    Amount--;
                }
            }
            else
            {
                _playerManager._itemList.Add(this.gameObject);
            }
            */
            if (_inventoryManager.CheckIfItemIsOntheList(_item))
            {
                if (Amount > 0)
                {
                    Amount--;
                }
            }
            else
            {
                _inventoryManager.AddItem(_item);
            }
        }

    }
}
