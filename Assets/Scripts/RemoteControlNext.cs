using UnityEngine;
using System.Collections;

namespace VRTK
{
    public class RemoteControlNext : VRTK.VRTK_InteractableObject
    {
        public GameObject TV;
        public override void OnInteractableObjectUsed(InteractableObjectEventArgs e)
        {
            base.OnInteractableObjectUsed(e);
            if (TV.GetComponent<HTC.UnityPlugin.Multimedia.TVMediaDecoder>())
            {
                TV.GetComponent<HTC.UnityPlugin.Multimedia.TVMediaDecoder>().NextMediaFile();
            }

        }
    }
}