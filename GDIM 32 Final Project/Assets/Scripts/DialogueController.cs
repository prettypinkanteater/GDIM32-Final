
using TMPro;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private DialogueUI _dialogueUI;
    [SerializeField] private DialogueNode _dialogueStartNode;

    private DialogueNode _currentNode;
    private int _currentLine = 0;
    private bool _runningDialogue;
    private bool _waitingForPlayerResponse;

    private void Start()
    {
        _currentNode = _dialogueStartNode;
    }

    private void Update()
    {
            if (!_waitingForPlayerResponse && Input.GetKeyDown(KeyCode.E) && Locator.Instance.player.lookingAt != null)
            {
                if (Locator.Instance.player.lookingAt.gameObject.tag == "manager")
            {
                AdvanceDialogue();
            }
                
            }
            else if (!_runningDialogue)
            {
                //
            }
    }

    private void AdvanceDialogue()
    {
        _runningDialogue = true;

        if (_currentLine < _currentNode._lines.Length)
        {
            // if we still have NPC lines left, keep playing NPC lines
            _dialogueUI.ShowDialogue(_currentNode._lines[_currentLine]);
            _currentLine++;
        }
        else if (_currentNode._playerReplyOptions != null && _currentNode._playerReplyOptions.Length > 0)
        {
            Debug.Log("Waiting for player");
            // show player dialogue options, if there are any
            _waitingForPlayerResponse = true;
            _dialogueUI.ShowPlayerOptions(_currentNode._playerReplyOptions);
        }
        else
        {
            // if there are no NPC or player lines left, close dialogue UI
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        _runningDialogue = false;
        _waitingForPlayerResponse = false;
        //_currentNode = _dialogueStartNode;
        _currentLine = 0;
        _dialogueUI.HideDialogue();
    }

    public void SelectedOption(int option)
    {
        _currentLine = 0;
        _waitingForPlayerResponse = false;

        _currentNode = _currentNode._npcReplies[option];
        AdvanceDialogue();
    }
}
