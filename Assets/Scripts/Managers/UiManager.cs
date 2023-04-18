using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
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
    [SerializeField] Animator ui_menu_animator;
    TextMeshProUGUI _textMeshProUGUI_coin_Total_value;


    //dialogue ui variables
    Animator _dialogue_panel_animator;
    //coin-Invenotry manager
    InventoryManager _inventoryManager;
    public TextMeshProUGUI _press_Button_text;

    private void Start()
    {
        _inventoryManager = GameObject.Find("Inventory Manager").GetComponent<InventoryManager>();
        _playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        _shopkeeper = GameObject.FindGameObjectWithTag("Shopkeeper").GetComponent<Shopkeeper>();
        _dialogue_panel_animator = GameObject.Find("Dialogue Panel").GetComponent<Animator>();
        _press_Button_text = GameObject.Find("text_press-space").GetComponent<TextMeshProUGUI>();
        _textMeshProUGUI_coin_Total_value = GameObject.Find("Coin Total Text").GetComponent<TextMeshProUGUI>();
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

        ui_menu_animator.SetBool("isOn", _playerInput.IsMenuOpen);

        _textMeshProUGUI_coin_Total_value.text = _inventoryManager._totalCoins.ToString();
    }

    public bool SetDialoguePanel(bool isOn)
    {
        return isOn;
    }
}
