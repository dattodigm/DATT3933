using System.Collections;
using UnityEngine;
using TMPro;


namespace DialogueSystem.Scripts.Core
{
    public class DialogueController : MonoBehaviour
    {
        [Header("UI References")]
        public UI.DialogueUI dialogueUI;

        [Header("Typing effect settings")]
        public float typingSpeed = 0.05f;
        public float punctuationDelay = 0.2f;

        [Header("Fade settings")]
        public float fadeSpeed = 2f;

        [Header("Input settings")]
        public KeyCode continueKey = KeyCode.Space;
        public KeyCode skipKey = KeyCode.Return;

        private DialogueData currentDialogue;
        private int currentLineIndex = 0;
        private bool isTyping = false;
        private bool isDialogueActive = false;
        private bool skipTyping = false;
        private Coroutine typingCoroutine;

        void Start()
        {
            if (dialogueUI != null)
            {
                dialogueUI.Hide();
                dialogueUI.SetAlpha(0f);
            }
        }

        void Update()
        {
            if (!isDialogueActive) return;

            // Space key to continue or skip typing
            if (Input.GetKeyDown(continueKey))
            {
                if (isTyping)
                {
                    skipTyping = true;
                }
                else
                {
                    ShowNextLine();
                }
            }

            // Enter key to skip entire dialogue
            if (Input.GetKeyDown(skipKey))
            {
                EndDialogue();
            }
        }

        public void StartDialogue(DialogueData dialogue)
        {
            if (dialogue == null || dialogue.lines.Length == 0)
            {
                Debug.LogWarning("The dialogue data is null or has no lines!");
                return;
            }

            currentDialogue = dialogue;
            currentLineIndex = 0;
            isDialogueActive = true;

            dialogueUI.Show();
            StartCoroutine(FadeIn(() => ShowCurrentLine()));
        }

        void ShowCurrentLine()
        {
            if (currentLineIndex >= currentDialogue.lines.Length)
            {
                if (currentDialogue.loopDialogue)
                {
                    currentLineIndex = 0;
                }
                else
                {
                    EndDialogue();
                    return;
                }
            }

            DialogueLine line = currentDialogue.lines[currentLineIndex];
            dialogueUI.SetupUI(line);

            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }

            typingCoroutine = StartCoroutine(TypeText(line));
        }

        void ShowNextLine()
        {
            currentLineIndex++;
            ShowCurrentLine();
        }

        IEnumerator TypeText(DialogueLine line)
        {
            isTyping = true;
            skipTyping = false;

            TextMeshProUGUI textComponent = dialogueUI.dialogueText;
            textComponent.text = line.text;
            textComponent.maxVisibleCharacters = 0;

            int totalCharacters = line.text.Length;

            for (int i = 0; i <= totalCharacters; i++)
            {
                if (skipTyping)
                {
                    textComponent.maxVisibleCharacters = totalCharacters;
                    break;
                }

                textComponent.maxVisibleCharacters = i;

                // Punctuation delay
                if (i > 0 && i < totalCharacters)
                {
                    char c = line.text[i - 1];
                    if (IsPunctuation(c))
                    {
                        yield return new WaitForSeconds(punctuationDelay);
                    }
                }

                yield return new WaitForSeconds(typingSpeed);
            }

            isTyping = false;

            // Autoplay next line after delay
            if (line.displayDuration > 0)
            {
                yield return new WaitForSeconds(line.displayDuration);
                ShowNextLine();
            }
        }

        bool IsPunctuation(char c)
        {
            return c == '.' || c == '!' || c == '?' || c == ',' || 
                   c == '。' || c == '，' || c == '！' || c == '？' || 
                   c == '；' || c == '：';
        }

        void EndDialogue()
        {
            StartCoroutine(FadeOut(() =>
            {
                isDialogueActive = false;
                dialogueUI.Hide();
            }));
        }

        IEnumerator FadeIn(System.Action onComplete = null)
        {
            float alpha = 0f;
            while (alpha < 1f)
            {
                alpha += fadeSpeed * Time.deltaTime;
                dialogueUI.SetAlpha(Mathf.Clamp01(alpha));
                yield return null;
            }
            dialogueUI.SetAlpha(1f);
            onComplete?.Invoke();
        }

        IEnumerator FadeOut(System.Action onComplete = null)
        {
            float alpha = 1f;
            while (alpha > 0f)
            {
                alpha -= fadeSpeed * Time.deltaTime;
                dialogueUI.SetAlpha(Mathf.Clamp01(alpha));
                yield return null;
            }
            dialogueUI.SetAlpha(0f);
            onComplete?.Invoke();
        }

        public bool IsDialogueActive()
        {
            return isDialogueActive;
        }
    }
}
