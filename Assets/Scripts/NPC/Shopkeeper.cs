using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : Interaction
{

    public bool _panelOn = false; 

    // Update is called once per frame
    void Update()
    {
        if(_playerInput != null)
        {
            if (_playerInput.IsInteracting) _panelOn = true;
            else _panelOn = false;
        }
       
    }
    
}
