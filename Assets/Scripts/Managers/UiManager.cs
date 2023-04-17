using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Script made by Flavio Alexandre
/// This Script is responsible for the manage of all UI behavior
/// </summary>
public class UiManager : MonoBehaviour
{
    public PlayerInput _playerInput;
    [Header("UI Shopkeeper")]
    Shopkeeper _shopkeeper;
    //Shop Panel Variables
    [SerializeField] Animator ui_itemShop_animator;
    [SerializeField] Animator ui_Inventory_animator;

    //dialogue ui variables
    Animator _dialogue_panel_animator;

    public TextMeshProUGUI _press_Button_text;

    private void Start()
    {
        _shopkeeper = GameObject.FindGameObjectWithTag("Shopkeeper").GetComponent<Shopkeeper>();
        _dialogue_panel_animator = GameObject.Find("Dialogue Panel").GetComponent<Animator>();
        _press_Button_text = GameObject.Find("text_press-space").GetComponent<TextMeshProUGUI>();
        _press_Button_text.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_shopkeeper.IsAShopkeeper) ui_itemShop_animator.SetBool("isOn", _shopkeeper._panelOn);

        ui_Inventory_animator.SetBool("isOn", _playerInput.IsInventoryOpen);

        if (_playerInput.CanInteract)
        {
            _press_Button_text.gameObject.SetActive(true);
        }
        else _press_Button_text.gameObject.SetActive(false);

        _dialogue_panel_animator.SetBool("isOn", _shopkeeper._panelOn);
    }

    public bool SetDialoguePanel(bool isOn)
    {
        return isOn;
    }
}
