using UnityEngine;
using System.Collections.Generic;

public class CarMovement : MonoBehaviour {

    // Displayed in the editor
    public float speed = 1f;
    public float verticalOffset = 0f;
    public List<GameObject> waypoints;

    float progress = 0f;
    int current = 0;

    Vector3 target;

    // Use this for initialization
    void Start () {
        target = waypoints[current].transform.position;
        target.y += verticalOffset;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(this.transform.position);

        if (current >= waypoints.Count)
        {
            this.enabled = false;
            return;
        }

        this.transform.position = Vector3.MoveTowards(this.transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(this.transform.position, target) < speed)
        {
            target = waypoints[++current].transform.position;
            target.y += verticalOffset;
        }
    }
}
