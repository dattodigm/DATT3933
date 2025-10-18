using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Teleporter : MonoBehaviour
{
    public Transform destination;
    public Transform playerReference;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("You should be teleporting");
            playerReference.position = destination.position;
            playerReference.rotation = destination.rotation;
        }
    }
}
