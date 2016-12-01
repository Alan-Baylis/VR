using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using VRTK;

public class MovieSceneHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("01_menu");
    }
}
