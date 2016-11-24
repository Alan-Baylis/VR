using UnityEngine;
using System.Collections;

namespace VRTK
{
    public class Radio_Button : VRTK_InteractableObject
    {
        private bool activated = true;


        public override void StartUsing(GameObject currentUsingObject)
        {
            OnInteractableObjectUsed(SetInteractableObjectEvent(currentUsingObject));
            usingObject = currentUsingObject;

            GetComponent<AudioSource>().Play();
              if(activated)
              {
                Debug.Log("Pausing");
                GetComponentInParent<AudioSource>().Pause();
                activated = false;
              } else
              {
                Debug.Log("Playin");
                GetComponentInParent<AudioSource>().Play();
                activated = true;
              }
              
        }
    }
}