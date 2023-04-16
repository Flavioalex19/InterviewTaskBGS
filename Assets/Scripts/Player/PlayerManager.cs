using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    //List<Item> _itemList = new List<Item>();//List for Items
    public List<GameObject> _itemList = new List<GameObject>();//List for Items

    int _coins;

    public InventoryManager _inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        _inventoryManager = GameObject.Find("Inventory Manager").GetComponent<InventoryManager>();

        //Verify wicht armor is equiped at the  start
        for (int i = 0; i < _itemList.Count; i++)
        {
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void AddItem(GameObject item)
    {
        _itemList.Add(item);
    }

}
