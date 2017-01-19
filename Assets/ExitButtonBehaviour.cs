using UnityEngine;
using System.Collections;

namespace VRTK
{
    public class ExitButtonBehaviour : VRTK_InteractableObject
    {
        public override void OnInteractableObjectTouched(InteractableObjectEventArgs e)
        {
            base.OnInteractableObjectTouched(e);
            GetComponentInChildren<ParticleSystem>().Play();
        }

        public override void OnInteractableObjectUntouched(InteractableObjectEventArgs e)
        {
            base.OnInteractableObjectUntouched(e);
            GetComponentInChildren<ParticleSystem>().Stop();
        }

        public override void OnInteractableObjectUsed(InteractableObjectEventArgs e)
        {
            base.OnInteractableObjectUsed(e);

            if (GetComponent<SteamVR_LoadLevel>())
            {
                GetComponent<SteamVR_LoadLevel>().Trigger();
            }
            else
            {
#if UNITY_EDITOR
                if(UnityEditor.EditorApplication.isPlaying)
                {
                    UnityEditor.EditorApplication.ExecuteMenuItem("Edit/Play");
                }
#endif
                Application.Quit();
            }
        }
    }

}