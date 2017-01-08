using UnityEngine;
using System.Collections;

namespace VRTK
{
    public class Radio_Button : VRTK_InteractableObject
    {
        private bool activated = true;
        public AudioSource ButtonSource;


        public override void StartUsing(GameObject currentUsingObject)
        {
            OnInteractableObjectUsed(SetInteractableObjectEvent(currentUsingObject));
            usingObject = currentUsingObject;

            GetComponent<AudioSource>().Play();
              if(activated)
              {
                Debug.Log("Pausing");
                ButtonSource.GetComponent<RadioBehaviourScript>().TurnRadioOff();
                activated = false;
              } else
              {
                Debug.Log("Playin");
                ButtonSource.GetComponent<RadioBehaviourScript>().TurnRadioOn();
                activated = true;
              }
              
        }
    }
}