using UnityEngine;
using System.Collections;

namespace VRTK
{
    public class Show_Details : VRTK.VRTK_InteractableObject
    {

        public GameObject Tooltip;

        protected override void Start()
        {
            Tooltip.SetActive(false);
        }

        override public void StartTouching(GameObject currentTouchingObject)
        {
            if (!touchingObjects.Contains(currentTouchingObject))
            {
                touchingObjects.Add(currentTouchingObject);
                OnInteractableObjectTouched(SetInteractableObjectEvent(currentTouchingObject));
                Tooltip.SetActive(true);
            }
        }

       public void SetInactive()
        {
            Tooltip.SetActive(false);
        }


    }
}