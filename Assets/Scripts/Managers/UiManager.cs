using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script made by Flavio Alexandre
/// This Script is responsible for the manage of all UI behavior
/// </summary>
public class UiManager : MonoBehaviour
{
    public PlayerInput _playerInput;
    [Header("UI Shopkeeper")]
    public Shopkeeper Shopkeeper;
    //Shop Panel Variables
    [SerializeField] Animator ui_itemShop_animator;

    [SerializeField] Animator ui_Inventory_animator;

    // Update is called once per frame
    void Update()
    {
        ui_itemShop_animator.SetBool("isOn", Shopkeeper._panelOn);
        ui_Inventory_animator.SetBool("isOn", _playerInput.IsInventoryOpen);
    }
}
