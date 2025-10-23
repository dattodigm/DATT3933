using UnityEngine;
using UnityEngine.UI;

public class ObjectiveTextureHeirarchy : MonoBehaviour
{
    public Transform RoadLocation;
    public Transform River1Location;
    public Transform River2Location;
    public Transform ForestLocation;
    public Transform PeopleLocation;

    private Transform currentObjective;
    public Camera mainCam;

    public float fadeStartDistance = 10f;
    public float fadeEndDistance = 20f;

    public Image Crosshair;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentObjective = ForestLocation;
    }

    // Update is called once per frame
    void Update()
    {
        float minX = Crosshair.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = Crosshair.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;

        Vector2 position = mainCam.WorldToScreenPoint(currentObjective.position);

        position.x = Mathf.Clamp(position.x, minX, maxX);
        position.y = Mathf.Clamp(position.y, minY, maxY);

        Crosshair.transform.position = position;

        float distance = Vector3.Distance(currentObjective.transform.position, mainCam.transform.position);

        // Calculate alpha based on distance
        float alpha = Mathf.InverseLerp(fadeEndDistance, fadeStartDistance, distance);
        alpha = Mathf.Clamp01(alpha); // Ensure alpha is between 0 and 1

        // Apply alpha to text color
        Color currentColor = Crosshair.color;
        currentColor.a = alpha;
        Crosshair.color = currentColor;
    }
}
