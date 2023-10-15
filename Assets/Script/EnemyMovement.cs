using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] float waitTime = 1f;
    [SerializeField] [Range(0f, 5f)] float speed = 1f;
    Enemy enemy;

    // Start is called before the first frame update
    void OnEnable()
    {
        FindPath();
        ReturntoStart();
        StartCoroutine(FollowPath());
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    // find path with tag in scene and save it to array
    void FindPath()
    {
        path.Clear();
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");
        foreach(GameObject waypoint in waypoints)
        {
            path.Add(waypoint.GetComponent<Waypoint>());
        }
    }

    // change enemy location to start path
    void ReturntoStart()
    {
        transform.position = path[0].transform.position;
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            // enemy start location
            Vector3 startPosition = transform.position;
            // the destination
            Vector3 endPosition = waypoint.transform.position;
            // progress to travel to the destination (range 0-1)
            float travelPercent = 0f;
            // make the object to look the path
            transform.LookAt(endPosition);

            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                // move smooth from start location to end location
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }

        }
        enemy.PenaltyGold();
        gameObject.SetActive(false);
    }
}
