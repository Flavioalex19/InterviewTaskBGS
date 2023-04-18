using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : Interaction
{
    [SerializeField] int _destinationIndex;
    UiManager _uiManager;

    private void Start()
    {
        //_playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        _uiManager = GameObject.Find("UI Manager").GetComponent<UiManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (_playerInput != null)
        {
            //Input.GetKeyDown(KeyCode.E)
            if (_playerInput.IsInteracting)
            {

                SceneManager.LoadScene(_destinationIndex);
            }
           

           
        }
    }

    public override void ActionInput()
    {
        SceneManager.LoadScene(_destinationIndex);
        print("Test555");
    }
}
