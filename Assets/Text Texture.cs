using UnityEngine;
using TMPro;
using UnityEngine.Rendering; // Or using UnityEngine.UI; for legacy Text

public class Text_Texture : MonoBehaviour
{
    public float fadeStartDistance = 10f;
    public float fadeEndDistance = 20f;
    private TextMeshPro textMesh; // Or Text textComponent;
    public VolumeProfile volumeEffect;

    void Start()
    {
        textMesh = GetComponent<TextMeshPro>(); // Or textComponent = GetComponent<Text>();
        if (textMesh == null)
        {
            Debug.LogError("TextMeshProUGUI component not found!");
            enabled = false;
        }
    }

    void Update()
    {
        if (Camera.main == null) return;

        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);

        // Calculate alpha based on distance
        float alpha = Mathf.InverseLerp(fadeEndDistance, fadeStartDistance, distance);
        alpha = Mathf.Clamp01(alpha); // Ensure alpha is between 0 and 1

        // Apply alpha to text color
        Color currentColor = textMesh.color;
        currentColor.a = alpha;
        textMesh.color = currentColor;
    }
}