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
    public Shopkeeper Shopkeeper;//adjust this

    //Shop Panel Variables
    [SerializeField] Animator ui_itemShop_animator;

    // Start is called before the first frame update
    void Start()
    {
        //if(Shopkeeper == null)Shopkeeper = GameObject.FindGameObjectWithTag("Shopkeeper").GetComponent<Shopkeeper>();
    }

    // Update is called once per frame
    void Update()
    {
        //ui_itemShop_animator.SetBool("isOn", _playerInput.IsInteracting);
        ui_itemShop_animator.SetBool("isOn", Shopkeeper._panelOn);
    }
}
