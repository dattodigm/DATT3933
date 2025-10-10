using UnityEngine;

namespace DialogueSystem.Scripts.Core
{
    [System.Serializable]
    public class DialogueLine
    {
        [Header("Dialogue Text")]
        [TextArea(3, 10)]
        public string text;

        [Header("Character Portrait")]
        public Sprite characterSprite;

        [Header("Character Name")]
        public string characterName;

        [Header("Display Settings")]
        [Tooltip("Auto-play duration in seconds, 0 for manual advance")]
        public float displayDuration = 0f;

        [Header("Text Style")]
        public Color textColor = Color.white;
        public int fontSize = 24;
    }
}