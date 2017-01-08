using UnityEngine;
using System.Collections;
namespace VRTK
{
    public class NextChannelButton : VRTK_InteractableObject {

        public GameObject Radio;

        public override void StartUsing(GameObject currentUsingObject)
        {

            Radio.GetComponent<RadioBehaviourScript>().ChangeChannelManually();

        }
    }
}