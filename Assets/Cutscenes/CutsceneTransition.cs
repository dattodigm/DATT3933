using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CutsceneTransition : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;

    Color targetColorBlack = new Color(0f, 0f, 0f, 1f); // Opaque black
    Color targetColorClear = new Color(0f, 0f, 0f, 0f); // Transparent

    public IEnumerator FadeOut()
    {
        fadeImage.gameObject.SetActive(true);
        Color startColor = fadeImage.color;
        
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            fadeImage.color = Color.Lerp(targetColorClear, targetColorBlack, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        fadeImage.color = targetColorBlack; // Ensure fully opaque
    }

    public IEnumerator FadeIn()
    {
        Color startColor = fadeImage.color;
        
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            fadeImage.color = Color.Lerp(targetColorBlack, targetColorClear, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        fadeImage.color = targetColorClear; // Ensure fully transparent
        fadeImage.gameObject.SetActive(false);
    }
}
