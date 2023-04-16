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
    public bool CanInteract = false;
    public bool IsInteracting = false;
    public bool IsInventoryOpen = false;

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
        if(CanInteract)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                IsInteracting = true;
            }
        }
        else
        {
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
