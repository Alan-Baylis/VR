using UnityEngine;
using System.Collections;
namespace VRTK
{
    public class NextChannelButton : VRTK_InteractableObject {

        public AudioSource Source;
        public AudioClip Clip1;
        public AudioClip Clip2;
        public AudioClip Clip3;


        public override void StartUsing(GameObject currentUsingObject)
        {
            Debug.Log("Starting to use");
            OnInteractableObjectUsed(SetInteractableObjectEvent(currentUsingObject));
            usingObject = currentUsingObject;

            GetComponent<AudioSource>().Play();

            if (Source.clip == Clip1)
            {
                Source.clip = Clip2;
            }
            else if (Source.clip == Clip2)
            {
                Source.clip = Clip3;
            } else
            {
                Source.clip = Clip1;
            }

            Source.Play();

        }
    }
}