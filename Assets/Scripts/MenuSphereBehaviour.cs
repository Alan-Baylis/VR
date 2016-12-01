using UnityEngine;
using System.Collections;


using UnityEngine.SceneManagement;
using VRTK;

public class MenuSphereBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private bool lastUsePressedState = false;

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
                SceneManager.LoadScene("01_menu");

            }
            lastUsePressedState = controller.usePressed;
        }
    }

}
