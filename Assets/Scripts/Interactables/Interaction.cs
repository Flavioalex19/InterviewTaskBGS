using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Script made by Flavio Alexandre
/// Script Attached to the child of the npc/item to intertact with player
/// </summary>
public class Interaction : MonoBehaviour
{

    [SerializeField]protected PlayerInput _playerInput;

    private void Update()
    {
        ActionInput();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _playerInput = collision.GetComponent<PlayerInput>();
            _playerInput.CanInteract = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _playerInput.CanInteract = false;
        _playerInput = null;

    }
    //Verify if the player pressed the button to interect
    public virtual bool ActionInput()
    {
        if (_playerInput.IsInteracting) return true;
        else return false;

    }
}
