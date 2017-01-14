using UnityEngine;
using System.Collections.Generic;

public class CarMovement : MonoBehaviour {

    private static Quaternion directionalOffset = Quaternion.Euler(0, 270, 0);

    // Displayed in the editor
    public float speed = 1f;
    public float verticalOffset = 0f;
    public List<GameObject> waypoints;

    float progress = 0f;
    int nextWaypoint = 0;

    Vector3 target;

    private void setNewTarget ()
    {
        // Setting the new target to the next entry in the target vector.
        target = waypoints[nextWaypoint].transform.position;
        target.y += verticalOffset;

        // Performing the rotation
        this.transform.rotation = Quaternion.LookRotation(target - this.transform.position) * directionalOffset;

        // Updating next waypoint
        if (++nextWaypoint >= waypoints.Count) { this.enabled = false; }
    }

    // Use this for initialization
    void Start () {
        setNewTarget();
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = Vector3.MoveTowards(this.transform.position, target, speed * Time.deltaTime);
        if (Vector3.Distance(this.transform.position, target) < speed) { setNewTarget(); }
    }
}
