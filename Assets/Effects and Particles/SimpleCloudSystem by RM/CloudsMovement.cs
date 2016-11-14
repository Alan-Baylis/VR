using UnityEngine;
using System.Collections;

public class CloudsMovement : MonoBehaviour {

    public Transform Player;
    public float CloudsSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(0, Time.deltaTime * CloudsSpeed, 0);
        // rotate 90 degrees around the object's local Y axis:
    }


    private float distance = 10.0f;

    private float height = 0.0f;
    private float heightDamping = 0.0f;
    private float rotationDamping = 0.0f;


   /* void LateUpdate()
    {



        if (!Player)
            return;

        var wantedHeight = Player.position.y + height;

        var currentHeight = transform.position.y;

        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        gameObject.transform.position = Player.position;

        gameObject.transform.position.Set = currentHeight;

    }*/
}
