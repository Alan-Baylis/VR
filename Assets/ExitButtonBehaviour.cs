using UnityEngine;
using System.Collections;

namespace VRTK
{
    public class ExitButtonBehaviour : VRTK_InteractableObject
    {


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