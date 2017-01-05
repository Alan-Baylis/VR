using UnityEngine;
using System.Collections;
using VRTK;

namespace VRKT {
    public class RemoteControlOnOff : VRTK.VRTK_InteractableObject
    {

        public GameObject TVScreen;

        private bool on = false;

        public override void OnInteractableObjectUsed(InteractableObjectEventArgs e)
        {
            base.OnInteractableObjectUsed(e);
            if(on)
            {
                TVScreen.GetComponent<HTC.UnityPlugin.Multimedia.MediaDecoder>().stopDecoding();
                on = false;
            } else
            {
                TVScreen.GetComponent<HTC.UnityPlugin.Multimedia.MediaDecoder>().SetAwake();
                on = true;
            }
            
        }

    }
}
