using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Progress;
using Unity.VisualScripting;
/// <summary>
/// Script made by Flavio Alexandre
/// This script is responsible for the item that is in the player inventory
/// This script manage to equip and sell items(in the inventory panel and shop panel, respectively )
/// </summary>
public class ItemInventory : MonoBehaviour
{
    PlayerInput _input;
    InventoryManager _inventoryManager;
    [Header("Index of the item")]
    [Tooltip("This Variable is responsible for identifying each Costume. This makes easier to equip and unequip each one of them")]
    public int MyItemIndex;
    //UI
    [Header("UI Elements")]
    [SerializeField] Image _item_Image;
    [SerializeField] Button _item_Sell_Button;
    [SerializeField] Button _item_Equip_Button;
    [SerializeField] TMP_Text _button_text;

    // Start is called before the first frame update
    void Start()
    {
        _input = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        _inventoryManager = GameObject.Find("Inventory Manager").GetComponent<InventoryManager>();
        _item_Equip_Button.onClick.AddListener(ChangeEquipedItem);
        _item_Sell_Button.onClick.AddListener(Sell);
    }

    // Update is called once per frame
    void Update()
    {
        //if the player is in the Shop panel the button for sell will be on and the button for equip will off
        if (_input.CanInteract)
        {
            _item_Sell_Button.gameObject.SetActive(true);
            _item_Equip_Button.gameObject.SetActive(false);
        }
        else
        {
            _item_Sell_Button.gameObject.SetActive(false);
            _item_Equip_Button.gameObject.SetActive(true);
        }
        //This for is to loop through the item list and change the button text, in the inventory panel 
        for (int i = 0; i < _inventoryManager._itemList.Count; i++)
        {

            //if this item is equiped, change the button text
            if (_inventoryManager._itemList[i].Index == MyItemIndex && _inventoryManager._itemList[i].IsEquiped)
            {
                _item_Equip_Button.transform.GetChild(0).GetComponent<TMP_Text>().SetText("Equiped");
                print(_inventoryManager._itemList[i]);
            }
            //the others costumes that are unequipped must have their text updated
            else if (_inventoryManager._itemList[i].Index == MyItemIndex && !_inventoryManager._itemList[i].IsEquiped)
            {
                _item_Equip_Button.transform.GetChild(0).GetComponent<TMP_Text>().SetText("Unequiped");
            }
            
        }
        
    }

    public void SetImage(Item item)
    {
        _item_Image.sprite = item.ItemSprite;
    }
    //Change the current Equipment
    void ChangeEquipedItem()
    {
        //Go throught all items
        for (int i = 0; i < _inventoryManager._itemList.Count; i++)
        {
            //Find the item tha we wishes to unequip
            if (_inventoryManager._itemList[i].IsEquiped && _inventoryManager._itemList[i].Index != MyItemIndex)
            {
                _inventoryManager._itemList[i].IsEquiped = false;

            }
            //Equip the desired item
            else if(!_inventoryManager._itemList[i].IsEquiped && _inventoryManager._itemList[i].Index == MyItemIndex) _inventoryManager._itemList[i].IsEquiped = true;
        }
        
    }
    void Sell()
    {
        gameObject.transform.SetParent(null);
        for (int i = 0; i < _inventoryManager._itemList.Count; i++)
        {
            if (_inventoryManager._itemList[i].Index == MyItemIndex)
            {
                _inventoryManager._itemList.Remove(_inventoryManager._itemList[i]);
                //Remove from inventory grid
                if(_inventoryManager._main_Character_Inventory.transform.GetChild(i).GetComponent<ItemInventory>().MyItemIndex == MyItemIndex) 
                    _inventoryManager._main_Character_Inventory.transform.GetChild(i).SetParent(null);
                _inventoryManager.SellItem(gameObject);

            }
        }
        /*
        _inventoryManager._itemList.Remove(_inventoryManager._itemList[MyItemIndex]);//remove from the list
        _inventoryManager.SellItem(gameObject);//Remove from inventory Panel
        */
    }
}
