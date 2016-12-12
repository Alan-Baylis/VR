﻿using UnityEngine;
using System.Collections;

namespace VRTK { 
public class ExitButtonBehaviour : VRTK_InteractableObject {


        public override void OnInteractableObjectUsed(InteractableObjectEventArgs e)
        {
            base.OnInteractableObjectUsed(e);

            if (GetComponent<SteamVR_LoadLevel>()) {

                GetComponent<SteamVR_LoadLevel>().Trigger();
            } else
            {
                Application.Quit();
            }
        }
    }

}