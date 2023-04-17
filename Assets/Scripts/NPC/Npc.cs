using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Npc : Interaction
{

    [SerializeField] List<string> _npcLines = new List<string>();
    public int _Myindex = 0;
    public bool _panelOn = false;

    public UiManager _uiManager;
    DialogueManager _dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("UI Manager").GetComponent<UiManager>();
        _dialogueManager = GameObject.Find("Dialogue Manager").GetComponent<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerInput != null)
        {
            if (_playerInput.IsInteracting) _panelOn = true;
            else _panelOn = false;



        }

        if (_panelOn)
        {
            _playerInput._move = Vector3.zero;
        }
        
    }
}
