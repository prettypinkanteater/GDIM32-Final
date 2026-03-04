using UnityEngine;

[CreateAssetMenu(fileName = "DialogueNode", menuName = "ScriptableObjects/DialogueNode", order = 1)]
public class DialogueNode : ScriptableObject
{
    
    public string[] _lines;

    public string[] _playerReplyOptions;

    public DialogueNode[] _npcReplies;
}
