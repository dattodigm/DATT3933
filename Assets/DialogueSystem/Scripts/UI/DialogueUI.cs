using DialogueSystem.Scripts.Core;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DialogueSystem.Scripts.UI
{
    public class DialogueUI : MonoBehaviour
    {
        [Header("UI Components")]
        public CanvasGroup canvasGroup;
        public GameObject dialoguePanel;
        public Image characterImage;
        public TextMeshProUGUI dialogueText;
        public TextMeshProUGUI characterNameText;

        [Header("Background Settings")]
        public Image panelBackground;

        public void SetupUI(DialogueLine line)
        {
            // Setup character portrait
            if (line.characterSprite != null)
            {
                characterImage.sprite = line.characterSprite;
                characterImage.enabled = true;
            }
            else
            {
                characterImage.enabled = false;
            }

            // Setup character name
            if (!string.IsNullOrEmpty(line.characterName))
            {
                characterNameText.text = line.characterName;
                characterNameText.gameObject.SetActive(true);
            }
            else
            {
                characterNameText.gameObject.SetActive(false);
            }

            // Setup dialogue text style
            dialogueText.color = line.textColor;
            dialogueText.fontSize = line.fontSize;
        }

        public void Show()
        {
            dialoguePanel.SetActive(true);
        }

        public void Hide()
        {
            dialoguePanel.SetActive(false);
        }

        public void SetAlpha(float alpha)
        {
            canvasGroup.alpha = alpha;
        }
    }
}