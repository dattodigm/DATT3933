using UnityEngine;

namespace DialogueSystem.Scripts.Core
{
    [CreateAssetMenu(fileName = "NewDialogue", menuName = "DialogueSystem/Dialogue Data")]
    public class DialogueData : ScriptableObject
    {
        [Header("Dialogue ID")]
        public string dialogueID;

        [Header("Dialogue Lines")]
        public DialogueLine[] lines;

        [Header("Dialog Loop switch")]
        public bool loopDialogue = false;
    }
}