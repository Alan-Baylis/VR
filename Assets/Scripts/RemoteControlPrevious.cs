using UnityEngine;
using System.Collections;
using VRTK;

namespace VRKT
{

    public class RemoteControlPrevious : VRTK.VRTK_InteractableObject
    {
        public GameObject TV;
        public override void OnInteractableObjectUsed(InteractableObjectEventArgs e)
        {
            base.OnInteractableObjectUsed(e);

            if (TV.GetComponent<HTC.UnityPlugin.Multimedia.TVMediaDecoder>())
            {
                TV.GetComponent<HTC.UnityPlugin.Multimedia.TVMediaDecoder>().PreviousMediaFile();
            }

        }

    }
}