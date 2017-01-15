using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;

public class AudioTime : MonoBehaviour {

    public int fontSize = 14;
    private Text text;

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
        text.fontSize = fontSize;
        text.text = "";
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (text != null && GameObject.FindGameObjectWithTag("AudioHandler").GetComponent<AudioHandlerScript>().IsNarrationPlaying())
        {
            text.text = "Kesto: " + GameObject.FindGameObjectWithTag("AudioHandler").GetComponent<AudioHandlerScript>().Duration();
        }
        else
        {
            text.text = "";
        }
    }
}
