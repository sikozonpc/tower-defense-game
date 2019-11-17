using System.Collections;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = WaypointsManager.waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        // Move the gameObject
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        // If we reach the waypoint
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            // Get next waypoint
            GetNextWaypoint();
        }   
    }

    private void GetNextWaypoint ()
    {
        // If reached the destination.
        if (waypointIndex >= WaypointsManager.waypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        waypointIndex++;
        target = WaypointsManager.waypoints[waypointIndex];
    }

    public static void SpawnEnemy (Transform _objectPrefab, Transform spawnPoint)
    {
        Instantiate(_objectPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
