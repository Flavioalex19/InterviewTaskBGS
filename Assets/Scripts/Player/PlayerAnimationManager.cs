using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
/// <summary>
/// Script made by Flavio Alexandre 
/// This Script is responsible for all the animations of the player character
/// </summary>
public class PlayerAnimationManager : MonoBehaviour
{


    //Components
    public Animator _playerAnimator;
    public AnimatorController MyController;
    public AnimatorOverrideController _controller;
    //public InventoryManager inventoryManager;
    InventoryManager _inventoryManager;
    PlayerInput _playerInput;

    private void Awake()
    {
        _inventoryManager = GameObject.Find("Inventory Manager").GetComponent<InventoryManager>();
        _playerInput = GetComponent<PlayerInput>();
        _playerAnimator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {

        //Verify wicht armor is equiped at the  start
        for (int i = 0; i < _inventoryManager._itemList.Count; i++)
        {
            if (_inventoryManager._itemList[i].MyItemType == ItemType.Outfit && _inventoryManager._itemList[i].IsEquiped)
            {
                ChangeAnimatorController(transform.GetChild(_inventoryManager._itemList[i].Index).GetComponent<Outfits>().Outfit.AnimatorOverrideController);


            }
            else return;
        }

    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimation();

        
    }
    //UYpdate the walking animations
    void UpdateAnimation()
    {
        _playerAnimator.SetFloat("moveX", _playerInput._move.x);
        _playerAnimator.SetFloat("moveY", _playerInput._move.y);

        for (int i = 0; i < _inventoryManager._itemList.Count; i++)
        {
            if (_inventoryManager._itemList[i].MyItemType == ItemType.Outfit)
            {
                //Get the animator controller correspondent of the equipped outfit 
                if (_inventoryManager._itemList[i].IsEquiped)
                {
                    ChangeAnimatorController(transform.GetChild(_inventoryManager._itemList[i].Index).GetComponent<Outfits>().Outfit.AnimatorOverrideController);
                }
                else
                {
                    //_inventoryManager._itemList[0].IsEquiped = true;
                    //_playerAnimationManager.ChangeAnimatorController(transform.GetChild(0).GetComponent<Outfits>().Outfit.AnimatorOverrideController);

                }
                //print(_inventoryManager._itemList[i].ItemName);

            }
            //else hasItemEquiped = true;
            //else _playerAnimationManager._playerAnimator.runtimeAnimatorController = _playerAnimationManager.MyController;
        }
        if (_inventoryManager._itemList.Count == 0)
        {
            _playerAnimator.runtimeAnimatorController = MyController;
        }
    }

    public void ChangeAnimatorController(AnimatorOverrideController animatorController)
    {
        _controller = animatorController;
        _playerAnimator.runtimeAnimatorController = _controller;
    }
}
