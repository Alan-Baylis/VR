using UnityEngine;
using System.Collections;

namespace VRTK
{
    

    public class VRTK_InteractableThrowable : VRTK_InteractableObject
    {
        public string CollidingWithTag;

        public override void Ungrabbed(GameObject previousGrabbingObject)
        {
            //Overriding this for the throwing mechanics to be re-enabled
            previousKinematicState = false;
            base.Ungrabbed(previousGrabbingObject);

        }


       void OnCollisionEnter(Collision hit)
        {
            Debug.Log(hit.collider.tag);
            if (hit.collider.tag == CollidingWithTag)
            {
                GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }

    
}