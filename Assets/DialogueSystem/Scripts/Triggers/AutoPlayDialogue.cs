using DialogueSystem.Scripts.Core;
using UnityEngine;

namespace DialogueSystem.Scripts.Triggers
{
    public class AutoPlayDialogue : MonoBehaviour
    {
        [Header("Dialogue Data")]
        public DialogueData dialogue;

        [Header("Controller Reference")]
        public DialogueController dialogueController;

        [Header("Dialogue Settings")]
        public bool playOnStart = true;
        public float delayBeforeStart = 0f;

        void Start()
        {
            if (dialogueController == null)
            {
                dialogueController = FindObjectOfType<DialogueController>();
            }

            if (playOnStart)
            {
                Invoke(nameof(PlayDialogue), delayBeforeStart);
            }
        }

        public void PlayDialogue()
        {
            if (dialogue != null && dialogueController != null)
            {
                dialogueController.StartDialogue(dialogue);
            }
        }
    }
}