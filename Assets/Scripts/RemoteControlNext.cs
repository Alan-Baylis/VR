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
            TV.GetComponent<HTC.UnityPlugin.Multimedia.MediaDecoder>().ChangeMediaFile("C:\\Users\\ygerg\\Downloads\\Tesoma_haast.mp4");
        }

    }
}