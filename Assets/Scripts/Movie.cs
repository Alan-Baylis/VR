using UnityEngine;
using System.Collections;

public class Movie : MonoBehaviour {

    public MovieTexture Video;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Renderer>().material.mainTexture = Video;
        Video.Play();
    }
}
