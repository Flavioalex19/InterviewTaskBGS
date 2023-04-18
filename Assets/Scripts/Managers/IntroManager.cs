using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    [SerializeField] List<string> _characterLines = new List<string>();
    int _myIndex;
    public bool _canStartSequence = true;

    DialogueManager _dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        _dialogueManager = GameObject.Find("Dialogue Manager").GetComponent<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_canStartSequence)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _dialogueManager.Dialogue(_characterLines, _myIndex, _canStartSequence);
                _myIndex++;
            }

        }
        if (_myIndex > _characterLines.Count)
        {
            SceneManager.LoadScene(1);
        }
        
    }
}
