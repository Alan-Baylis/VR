using UnityEngine;
using System.Collections;

public class CarMovement : MonoBehaviour {
    float speed;
    float progress;
    Vector3 current;
    Vector3 target;

    // Use this for initialization
    void Start () {
        current = this.transform.position;
        target = GameObject.Find("wp1").transform.position;
        speed = 0.01f;
        progress = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(this.transform.position);
        progress += speed * Time.deltaTime;

        this.transform.LookAt(target);
        this.transform.position = Vector3.Slerp(current, target, progress);
	}
}
