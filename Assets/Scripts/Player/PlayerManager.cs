using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    //List<Item> _itemList = new List<Item>();//List for Items
    //public List<GameObject> _itemList = new List<GameObject>();//List for Items

    public int _coins;

    InventoryManager _inventoryManager;
    PlayerAnimationManager _playerAnimationManager;

    //test
    public bool hasItemEquiped = false;

    private void Awake()
    {
        _inventoryManager = GameObject.Find("Inventory Manager").GetComponent<InventoryManager>();
        _playerAnimationManager = GetComponent<PlayerAnimationManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
       

        //Verify wicht armor is equiped at the  start
        for (int i = 0; i < _inventoryManager._itemList.Count; i++)
        {
            if(_inventoryManager._itemList[i].MyItemType == ItemType.Outfit && _inventoryManager._itemList[i].IsEquiped)
            {
                _playerAnimationManager.ChangeAnimatorController(transform.GetChild(_inventoryManager._itemList[i].Index).GetComponent<Outfits>().Outfit.AnimatorOverrideController); 


            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        /*
        for (int i = 0; i < _inventoryManager._itemList.Count; i++)
        {
            if (_inventoryManager._itemList[i].MyItemType == ItemType.Outfit && _inventoryManager._itemList[i].IsEquiped)
            {
                _playerAnimationManager.ChangeAnimatorController(transform.GetChild(_inventoryManager._itemList[i].Index).GetComponent<Outfits>().Outfit.AnimatorOverrideController);
                //print(_inventoryManager._itemList[i].ItemName);
                
            }
            //else hasItemEquiped = true;
            //else _playerAnimationManager._playerAnimator.runtimeAnimatorController = _playerAnimationManager.MyController;
        }
        */

        for (int i = 0; i < _inventoryManager._itemList.Count; i++)
        {
            if (_inventoryManager._itemList[i].MyItemType == ItemType.Outfit)
            {
                if (_inventoryManager._itemList[i].IsEquiped)
                {
                    _playerAnimationManager.ChangeAnimatorController(transform.GetChild(_inventoryManager._itemList[i].Index).GetComponent<Outfits>().Outfit.AnimatorOverrideController);
                }
                else
                {
                    _inventoryManager._itemList[0].IsEquiped = true;
                    //_playerAnimationManager.ChangeAnimatorController(transform.GetChild(0).GetComponent<Outfits>().Outfit.AnimatorOverrideController);
                }
                //print(_inventoryManager._itemList[i].ItemName);

            }
            //else hasItemEquiped = true;
            //else _playerAnimationManager._playerAnimator.runtimeAnimatorController = _playerAnimationManager.MyController;
        }
        if (_inventoryManager._itemList.Count == 0)
        {
            _playerAnimationManager._playerAnimator.runtimeAnimatorController = _playerAnimationManager.MyController;
        }
    }

    
    
    
}
