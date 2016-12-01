using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ToMurderScene()
    {
        Debug.Log("Murder Scene was clicked");
                // Load next level based on build list (File->Build settings->Scenes In Build)
                SceneManager.LoadScene("road");

    }

    public void ToVideoScene()
    {
        Debug.Log("Video Scene was clicked");
        // Load next level based on build list (File->Build settings->Scenes In Build)
        SceneManager.LoadScene("03_360video");

    }
}
