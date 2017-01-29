using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using VRTK;

public class AudioTime : VRTK_ObjectTooltip
{

	// Update is called once per frame
	void FixedUpdate () {
        if (displayText != null && GameObject.FindGameObjectWithTag("AudioHandler").GetComponent<AudioHandlerScript>().IsNarrationPlaying())
        {
            //text.text = "Kesto: " + GameObject.FindGameObjectWithTag("AudioHandler").GetComponent<AudioHandlerScript>().Duration();
            UpdateText("Kesto: " + GameObject.FindGameObjectWithTag("AudioHandler").GetComponent<AudioHandlerScript>().Duration());
        }
        else
        {
            //text.text = "";
            UpdateText("");
        }
    }
}
