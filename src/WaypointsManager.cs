using UnityEngine;

public class WaypointsManager : MonoBehaviour
{
    public static Transform[] waypoints;

    private void Awake()
    {
        // Setting the length of the array
        waypoints = new Transform[transform.childCount];

        // Filling up the array with its children
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }
    }
}
