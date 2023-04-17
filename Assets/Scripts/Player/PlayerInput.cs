using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
/// <summary>
/// Script Made by Flavio Alexandre
/// Script related to all input actios that the player can execute
/// </summary>
public class PlayerInput : MonoBehaviour
{

    //Variables
    //Public Variables
    #region Public Variables
    public bool CanInteract = false;
    public bool IsInteracting = false;
    public bool IsInventoryOpen = false;
    #endregion
    //Private Variables
    public Vector3 _move;
    //Components
    Movement _movement;

    

    // Start is called before the first frame update
    void Start()
    {
        _movement = GetComponent<Movement>();
        
        
    }
    private void Update()
    {
        //If the p´layer com interct with the interactable
        if(CanInteract)
        {
            //display the shop panel
            if(Input.GetKeyDown(KeyCode.F))
            {
                print("Space");
                IsInteracting = !IsInteracting;
            }
        }
        else
        {
            //Display the inventory
            if (Input.GetKeyDown(KeyCode.I))
            {
                IsInventoryOpen = !IsInventoryOpen;
            }
        }

        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        _move = Vector3.zero;
        _move.x = Input.GetAxis("Horizontal");
        _move.y = Input.GetAxis("Vertical");
        _movement.Move(_move);
    }
}
