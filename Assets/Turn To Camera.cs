using Unity.Cinemachine;
using UnityEngine;

//Place on Canvas Object
// Text -> Canvas (this) -> Model Object (-> =  is parented to...)
public class Turn_To_Camera: MonoBehaviour
{
    private Transform mainCam;
    public Camera cameraObject;

    private void OnEnable()
    {
        mainCam = cameraObject.transform;
        Debug.Log("Main Cam = " + mainCam.name);
    }

    private void LateUpdate()
    {
        transform.LookAt(mainCam);
        transform.RotateAround(transform.position, transform.up, 180f);
    }
}