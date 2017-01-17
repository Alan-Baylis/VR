using UnityEngine;
using System.Collections;

namespace VRTK
{
    

    public class VRTK_InteractableThrowable : VRTK_InteractableObject
    {

        public override void Ungrabbed(GameObject previousGrabbingObject)
        {
            //Overriding this (hacky) for the throwing mechanics to be re-enabled
            previousKinematicState = false;
            base.Ungrabbed(previousGrabbingObject);

        }



    }

    
}