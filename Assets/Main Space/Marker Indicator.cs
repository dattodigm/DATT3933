using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarkerIndicator : MonoBehaviour
{
    public GameObject Restored;
    public GameObject Destroyed;

    public CutsceneSetup cutsceneSetup;
    public Collision containingBox;
    public string overrwiteToken;
    public int videoLength;

    public PlayerMovement playerMovement;
    public CameraMovement cameraMovement;

    bool done;

    private void Awake() {
        Restored.SetActive(false);
        Destroyed.SetActive(true);
        done = false;
    }

    void OnTriggerEnter(Collider other) {
        if (done == false)
        {
            playerMovement.enabled = false;
            cameraMovement.enabled = false;
            cutsceneSetup.PlayDemoCutscene(videoLength, overrwiteToken);
            StartCoroutine(MyDelayedAction());
        }
    }

    IEnumerator MyDelayedAction()
    {
        Debug.Log("Watching Movie");
        yield return new WaitForSeconds(videoLength);
        playerMovement.enabled = true;
        cameraMovement.enabled = true;
        Restored.SetActive(true);
        Destroyed.SetActive(false);
        done = true;
        Debug.Log("Finished Movie");
    }
}
