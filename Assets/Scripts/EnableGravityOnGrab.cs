using UnityEngine;
using System.Collections;

public class EnableGravityOnGrab : MonoBehaviour
{

    // Get event handlers
    void Start()
    {
        GetComponent<VRTK.VRTK_InteractableObject>().InteractableObjectGrabbed += new VRTK.InteractableObjectEventHandler(EnableGravity);
    }

    void EnableGravity(object sender, VRTK.InteractableObjectEventArgs e)
    {
        GetComponent<BoxCollider>().isTrigger = false;
        GetComponent<Rigidbody>().useGravity = true;

    }
}
