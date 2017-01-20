using UnityEngine;
using System.Collections;

namespace VRTK
{
    

    public class VRTK_InteractableThrowable : VRTK_InteractableObject
    {

        public float playThrowSound = 5.0f;

        public override void Ungrabbed(GameObject previousGrabbingObject)
        {
            //Overriding this (hacky) for the throwing mechanics to be re-enabled
            previousKinematicState = false;
            base.Ungrabbed(previousGrabbingObject);

        }


        protected override void Update()
        {
            base.Update();


            if( GetComponent<Rigidbody>().velocity.magnitude > playThrowSound && !GetComponent<AudioSource>().isPlaying )
            {
                GetComponent<AudioSource>().Play();
            }
        }
    }

    
}