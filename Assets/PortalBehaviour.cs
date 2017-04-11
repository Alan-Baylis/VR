using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Analytics;
using System.Collections;
using System.Collections.Generic;

namespace VRTK
{
    public class PortalBehaviour : VRTK_InteractableObject
    {
        public UnityEngine.UI.Button btn;

        protected override void Start()
        {
            base.Start();
            GetComponent<Collider>().enabled = false;

        }
        public override void OnInteractableObjectTouched(InteractableObjectEventArgs e)
        {
            base.OnInteractableObjectTouched(e);
            btn.Select();
        }

        public override void OnInteractableObjectUntouched(InteractableObjectEventArgs e)
        {
            base.OnInteractableObjectUntouched(e);
            EventSystem.current.SetSelectedGameObject(null);
        }
        public override void OnInteractableObjectUsed(InteractableObjectEventArgs e)
        {
            base.OnInteractableObjectUsed(e);

            Analytics.CustomEvent("levelLoaded", new Dictionary<string, object>
        {
            { "name", GetComponent<SteamVR_LoadLevel>().levelName},
        });

            if (GetComponent<SteamVR_LoadLevel>())
            {
                GetComponent<SteamVR_LoadLevel>().Trigger();
            }

        }
    }
}