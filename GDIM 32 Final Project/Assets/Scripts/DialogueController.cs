
using TMPro;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private DialogueUI _dialogueUI;
    [SerializeField] private DialogueNode _dialogueStartNode;
    [SerializeField] private DialogueNode _fryCheckInNode;

    private DialogueNode _currentNode;
    private int _currentLine = 0;
    private bool _runningDialogue;
    private bool _waitingForPlayerResponse;

    public delegate void TalkedToManager();
    public event TalkedToManager StartFryQuest;

    private void Start()
    {
        _currentNode = _dialogueStartNode;
    }

    private void Update()
    {
            if (!_waitingForPlayerResponse && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)))
            {
                if (_runningDialogue)
                {
                    AdvanceDialogue();
                }
            }
            else if (!_runningDialogue && Input.GetKeyDown(KeyCode.E))
            {
                if (Locator.Instance.gameController.inDialogue || Locator.Instance.player.dialoguePromptOn)
                {
                AdvanceDialogue();
                }
            }
    }

    private void AdvanceDialogue()
    {
        _runningDialogue = true;
        Locator.Instance.ui.hidePrompt();
        Locator.Instance.ui.hideDialoguePrompt();

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

        if (!Locator.Instance.gameController.fryInProgress && !Locator.Instance.gameController.fryDone)
        {
            Locator.Instance.gameController.fryInProgress = true;
            StartFryQuest.Invoke();
            _currentNode = _fryCheckInNode;
        }
    }

    public void SelectedOption(int option)
    {
        _currentLine = 0;
        _waitingForPlayerResponse = false;

        _currentNode = _currentNode._npcReplies[option];
        AdvanceDialogue();
    }
}
