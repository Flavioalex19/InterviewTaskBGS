using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    //List<Item> _itemList = new List<Item>();//List for Items
    public List<GameObject> _itemList = new List<GameObject>();//List for Items

    int _coins;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool CheckIfItemIsOntheList(Item item)
    {
        bool isOnTheList = false;
        for (int i = 0; i < _itemList.Count; i++)
        {
            if (item.ItemName == _itemList[i].GetComponent<ItemDisplay>()._item.ItemName)
            {
                isOnTheList = true;
                return  true;

            }
            else
            {
                isOnTheList = false;


            }
        }
        return isOnTheList;
    }
    public void AddItem(GameObject item)
    {
        _itemList.Add(item);
    }

}
