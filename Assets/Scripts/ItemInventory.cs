using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemInventory : MonoBehaviour
{
    public PlayerInput input;
    InventoryManager inventoryManager;
    public int MyItemIndex;
    //UI
    [Header("UI Elements")]
    [SerializeField] Image _item_Image;
    [SerializeField] Button _item_Sell_Button;
    [SerializeField] Button _item_Equip_Button;

    // Start is called before the first frame update
    void Start()
    {
        input = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        inventoryManager = GameObject.Find("Inventory Manager").GetComponent<InventoryManager>();
        _item_Equip_Button.onClick.AddListener(ChangeEquipedItem);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (input.CanInteract)
        {
            _item_Sell_Button.gameObject.SetActive(true);
            _item_Equip_Button.gameObject.SetActive(false);
        }
        else
        {
            _item_Sell_Button.gameObject.SetActive(false);
            _item_Equip_Button.gameObject.SetActive(true);
        }
        
    }

    public void SetImage(Item item)
    {
        _item_Image.sprite = item.ItemSprite;
    }

    void ChangeEquipedItem()
    {
        for (int i = 0; i < inventoryManager._itemList.Count; i++)
        {
            if (inventoryManager._itemList[i].IsEquiped && inventoryManager._itemList[i].Index != MyItemIndex)
            {
                inventoryManager._itemList[i].IsEquiped = false;
                print(inventoryManager._itemList[i].ItemName + "Has changed");
            }
        }
        for (int i = 0;i < inventoryManager._itemList.Count; i++)
        {
            if (inventoryManager._itemList[i].Index == MyItemIndex)
            {
                inventoryManager._itemList[i].IsEquiped = true;
                print(inventoryManager._itemList[i].ItemName + "new equip");
            }
        }
    }

    void SellItem()
    {
        //I can only sell unequiped items

    }
}
