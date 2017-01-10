using UnityEngine;
using System.Collections;

public class BrokenDoorBehaviour : MonoBehaviour {

    private HingeJoint joint;
	// Use this for initialization
	void Start () {
        joint = GetComponent<HingeJoint>();
	}
	
	// Update is called once per frame
	void Update () {
	    
        if(!joint)
        {
            GetComponent<Rigidbody>().useGravity = enabled;
            GetComponent<VRTK.VRTK_InteractableObject>().grabAttachMechanic = VRTK.VRTK_InteractableObject.GrabAttachType.Child_Of_Controller;
        }
	}
}
