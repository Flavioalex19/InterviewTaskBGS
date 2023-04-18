using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script made by Flavio Alexandre
/// This Script was made, at the start, for the only npc on the project.
/// Through the development, the idea of a new npc to guide the player to the item shop
///Instead of create a new script derivative from interaction, i opted for use this script instead
/// </summary>
public class Shopkeeper : Interaction
{
    #region private Variable
    UiManager _uiManager;
    DialogueManager _dialogueManager;
    Button button_next_Line;
    Button button_close_Panel;
    [SerializeField] List<string> _npcLines = new List<string>();
    #endregion
    [Header("References")]
    public int _Myindex = 0;
    public bool _panelOn = false;
    public bool IsAShopkeeper = true;



    private void Start()
    {
        _playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        _uiManager = GameObject.Find("UI Manager").GetComponent<UiManager>();
        _dialogueManager = GameObject.Find("Dialogue Manager").GetComponent<DialogueManager>();
        button_next_Line = GameObject.Find("Next Button").GetComponent<Button>();
        button_close_Panel = GameObject.Find("Close Panel").GetComponent<Button>();
        //Set up buttons
        button_next_Line.onClick.AddListener(DialogueForward);
        button_close_Panel.onClick.AddListener(SetIsInteracting);
    }

    // Update is called once per frame
    void Update()
    {
        //if the player has entered the trigger
        if(_playerInput != null)
        {
            //_uiManager._press_Button_text.SetText("Press F To Enter");
            if (_playerInput.IsInteracting) 
            {
                _panelOn = true;
                _playerInput.enabled = false;
                
            } 
            else
            {
                _panelOn = false;
                _playerInput.enabled = true;
            }
            
            
            
        }

       

    }
    //Not for the shop keeper
    void DialogueForward()
    {
        if (_Myindex < _npcLines.Count)
        {
            _uiManager.SetDialoguePanel(true);
            _dialogueManager.Dialogue(_npcLines, _Myindex, _panelOn);
            _Myindex++;
        }
        else
        {
            _uiManager.SetDialoguePanel(false);
            _Myindex = 0;
            StartCoroutine(WaitSeconds());
            if(!IsAShopkeeper) _playerInput.IsInteracting = false;
            //_playerInput.IsInteracting = false;
        }
    }
    void SetIsInteracting()
    {
        _playerInput.IsInteracting = false;
    }
    IEnumerator WaitSeconds()
    {
        yield return new WaitForSeconds(1);
    }

    
}
