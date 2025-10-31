using UnityEngine;
using UnityEngine.Events;

namespace DialogueSystem.Scripts
{
    public class DialogueTrigger : MonoBehaviour
    {
        [Header("Events")]
        public UnityEvent startDialogueEvent;
        public UnityEvent nextSentenceDialogueEvent;
        public UnityEvent endDialogueEvent;
    }
}