using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : Interaction
{

    [SerializeField]List<GameObject> _itemsItens = new List<GameObject>();

    public bool _panelOn = false; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
