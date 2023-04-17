using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{

    

    //Components
    PlayerInput _playerInput;
    public Animator _playerAnimator;
    public AnimatorController MyController;
    public AnimatorOverrideController _controller;
    public InventoryManager inventoryManager;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerAnimator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        //_playerAnimator.runtimeAnimatorController = transform.GetChild(inventoryManager._itemList[0].Index = 0).GetComponent<Outfits>().Outfit.AnimatorController;
        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        _playerAnimator.SetFloat("moveX", _playerInput._move.x);
        _playerAnimator.SetFloat("moveY", _playerInput._move.y);
    }

    public void ChangeAnimatorController(AnimatorOverrideController animatorController)
    {
        _controller = animatorController;
        _playerAnimator.runtimeAnimatorController = _controller;
    }
}
