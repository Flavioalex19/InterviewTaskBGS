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
        _uiManager = GameObject.Find("UI Manager").GetComponent<UiManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (_playerInput != null)
        {
            if (_playerInput.IsInteracting)
            {

                SceneManager.LoadScene(_destinationIndex);
            }
           

           
        }
    }
}
