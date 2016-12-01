using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using VRTK;

public class LevelChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	/**
	* Below is taken from VRTK Example #27: Teleportation by model village (ModelVillage_TeleportLocaltion.cs)
	**/
	
	// Keeps track of usePressed
	private bool lastUsePressedState = false;

	// Function what to do while something (controller) is colliding
	private void OnTriggerStay(Collider collider)
	{
       
		// Try to get controller (controller must have VRTK_ControllerEvents script attached to it!)
		var controller = (collider.GetComponent<VRTK_ControllerEvents>() ? collider.GetComponent<VRTK_ControllerEvents>() : collider.GetComponentInParent<VRTK_ControllerEvents>());
		if (controller)
		{
			if (lastUsePressedState == true && !controller.usePressed)
			{
                Debug.Log("The scene change was called");
                // Get index of curren Scene
                int currentIndex = SceneManager.GetActiveScene().buildIndex;

                // Load next level based on build list (File->Build settings->Scenes In Build)
                 SceneManager.LoadScene("road"); 

			}
			lastUsePressedState = controller.usePressed;
		}
	}
}
