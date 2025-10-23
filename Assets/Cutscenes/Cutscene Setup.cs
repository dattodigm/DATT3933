using UnityEngine;
using System.Collections;
using UnityEngine.Video;

public class CutsceneSetup : MonoBehaviour
{
    public VideoClip SourceDemo;
    public VideoPlayer projector;
    public RenderTexture renderTexture;
    public CutsceneTransition transition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ClearRenderTexture(renderTexture, new Color(0f, 0f, 0f, 0f));

        projector.clip = null;
        projector.targetTexture = renderTexture;

        // Subscribe to the loopPointReached event
        if (projector != null)
        {
            projector.loopPointReached += OnVideoEnd;
        }
    }

    // THE TOKEN ARE AS FOLLOWS: FOREST, RIVER, OVERPASS, PEOPLE
    public void PlayDemoCutscene(int videoLength, string locationToken)
    {
        StartCoroutine(transition.FadeOut());

        if (locationToken.Equals("FOREST"))
        {
            projector.clip = SourceDemo;
        }

        StartCoroutine(DelayBeforePlaying());
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        ClearRenderTexture(renderTexture, new Color(0f, 0f, 0f, 0f));
        projector.clip = null;

        StartCoroutine(transition.FadeIn());
    }

    public void ClearRenderTexture(RenderTexture renderTexture, Color clearColor)
    {
        // Store the currently active RenderTexture
        RenderTexture originalActive = RenderTexture.active;

        // Set the target RenderTexture as active
        RenderTexture.active = renderTexture;

        // Clear the active RenderTexture with the specified color
        GL.Clear(true, true, clearColor); // true for clearing color, true for clearing depth, clearColor

        // Restore the original active RenderTexture
        RenderTexture.active = originalActive;
    }

    IEnumerator DelayBeforePlaying()
    {
        Debug.Log("Transitioning");
        yield return new WaitForSeconds(transition.fadeDuration);
        projector.Play();
    }
}
