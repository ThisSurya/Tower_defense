using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] GameObject towerPrefab;
    public bool IsPlaceable{ get{return isPlaceable;} }

    // Place the tower
    void OnMouseDown() {
        if(isPlaceable)
        {
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            // the lane can't be place twice
            isPlaceable = false;
        }
    }
}
