using UnityEngine;
using System.Collections;

public class AudioColliderBehaviour : MonoBehaviour {

    void OnTriggerEnter (Collider other)
    {
        Debug.Log("There was somethign here");
        gameObject.GetComponent<AudioSource>().Play();

    }

    void OnTriggerExit (Collider other)
    {
        Debug.Log("Something exited the trigger volume.");
        gameObject.GetComponent<AudioSource>().Pause();


    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
