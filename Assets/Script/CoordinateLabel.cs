using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabel : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color newColor = Color.gray;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

    void Awake() {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();
    }

    void Update()
    {
       if(!Application.isPlaying)
       {
           DisplayCoordinates();
           UpdateObjectName();
       } 

        ColorCoordinates();
        ToggleLabel();
    }

    void ColorCoordinates()
    {
        if(waypoint.IsPlaceable)
        {
            // coordinates color text when the tower is placeable
            label.color = defaultColor;
        }
        else
        {
            // coordinates color text when the tower isn't placeable
            label.color = newColor;
        }
    }

    void ToggleLabel()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            label.enabled = !label.IsActive();
        }
    }

    // display the coordinate in the grid
    void DisplayCoordinates() 
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }

}
