using UnityEngine;
using System.Collections;
using VRTK;

namespace VRKT {
    public class RemoteControlOnOff : VRTK.VRTK_InteractableObject
    {

        public GameObject TVScreen;

        public override void OnInteractableObjectUsed(InteractableObjectEventArgs e)
        {
            base.OnInteractableObjectUsed(e);
            TVScreen.GetComponent<HTC.UnityPlugin.Multimedia.TVMediaDecoder>().SetAwake();
            
        }

    }
}
