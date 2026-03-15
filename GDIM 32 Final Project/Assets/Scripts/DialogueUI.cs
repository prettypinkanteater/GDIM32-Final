using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _npcText;
    [SerializeField] private GameObject _npcDialogue;
    [SerializeField] private GameObject _playerOptions;
    [SerializeField] private TMP_Text reply1;
    [SerializeField] private TMP_Text reply2;
    [SerializeField] private TMP_Text reply3;

    public void ShowDialogue(string dialogue)
    {
        Locator.Instance.gameController.inDialogue = true;
        gameObject.SetActive(true);

        _npcDialogue.SetActive(true);
        _playerOptions.SetActive(false);

        _npcText.text = dialogue;
    }

    public void ShowPlayerOptions()
    {
        Cursor.lockState = CursorLockMode.None;

        gameObject.SetActive(true);
        
        _npcDialogue.SetActive(false);
        _playerOptions.SetActive(true);
    }

    public void ShowPlayerOptions(string[] options)
    {
        Cursor.lockState = CursorLockMode.None;

        gameObject.SetActive(true);

        _npcDialogue.SetActive(false);
        _playerOptions.SetActive(true);

        reply1.text = options[0];

        if (options.Length >= 2)
        {
            reply2.transform.parent.gameObject.SetActive(true);
            reply2.text = options[1];
        }
        else
        {
            reply2.transform.parent.gameObject.SetActive(false);
        }

        if (options.Length >= 3)
        {
            reply3.transform.parent.gameObject.SetActive(true);
            reply3.text = options[2];
        }
        else
        {
            reply3.transform.parent.gameObject.SetActive(false);
        }
    }

    public void HideDialogue()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Locator.Instance.gameController.inDialogue = false;

        _playerOptions.SetActive(false);
        _npcDialogue.SetActive(false);
        gameObject.SetActive(false);
        
    }
}