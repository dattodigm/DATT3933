using DialogueSystem.Scripts.Core;
using UnityEngine;

namespace DialogueSystem.Scripts.Triggers
{
    [RequireComponent(typeof(Collider2D))]
    public class DialogueTrigger : MonoBehaviour
    {
        [Header("Dialogue Data")]
        public DialogueData dialogue;

        [Header("Controller Reference")]
        public DialogueController dialogueController;

        [Header("Trigger Settings")]
        public KeyCode interactionKey = KeyCode.E;
        public bool triggerOnEnter = false;
        public bool canRepeat = true;

        [Header("UI of the interaction prompt")]
        public GameObject interactionPrompt;

        private bool playerInRange = false;
        private bool hasTriggered = false;

        void Start()
        {
            if (interactionPrompt != null)
            {
                interactionPrompt.SetActive(false);
            }

            if (dialogueController == null)
            {
                dialogueController = FindObjectOfType<DialogueController>();
            }
        }

        void Update()
        {
            if (playerInRange && !hasTriggered)
            {
                if (triggerOnEnter || Input.GetKeyDown(interactionKey))
                {
                    TriggerDialogue();
                }
            }
        }

        void TriggerDialogue()
        {
            if (dialogue != null && dialogueController != null)
            {
                dialogueController.StartDialogue(dialogue);
                
                if (!canRepeat)
                {
                    hasTriggered = true;
                }

                if (interactionPrompt != null)
                {
                    interactionPrompt.SetActive(false);
                }
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = true;
                
                if (interactionPrompt != null && (canRepeat || !hasTriggered))
                {
                    interactionPrompt.SetActive(true);
                }

                if (triggerOnEnter && (canRepeat || !hasTriggered))
                {
                    TriggerDialogue();
                }
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = false;
                
                if (interactionPrompt != null)
                {
                    interactionPrompt.SetActive(false);
                }
            }
        }
    }
}
