using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    InventoryManager _inventoryManager;


    public Button button_Quit;

    // Start is called before the first frame update
    void Start()
    {
        _inventoryManager = GameObject.Find("Inventory Manager").GetComponent<InventoryManager>();
        button_Quit = GameObject.Find("Quit Button").GetComponent<Button>();

        button_Quit.onClick.AddListener(Quit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Quit()
    {
        Application.Quit();
    }


}
