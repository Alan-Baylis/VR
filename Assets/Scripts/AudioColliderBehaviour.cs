using UnityEngine;
using System.Collections;

public class AudioColliderBehaviour : MonoBehaviour {

    [Tooltip("Use with caution: evaluates only, if player has entered the volume.")]
    public bool playsOnlyOnce = false;
    private bool hasBeenPlayed = false;


    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter (Collider other) {

        if (playsOnlyOnce && !hasBeenPlayed)
        {
            StartCoroutine(FadeAudioIn());
            hasBeenPlayed = true;
        } else if (playsOnlyOnce && hasBeenPlayed) {
            Debug.Log("Tämä pätkä soiteltiin jo.");
        } else
        {
           StartCoroutine(FadeAudioIn());
        }
        
    }
    
    void OnTriggerExit (Collider other)
    {
        Debug.Log("Something exited the trigger volume.");
        StartCoroutine(FadeAudioOut());

    }

    IEnumerator FadeAudioOut()
    {
        while(GetComponent<AudioSource>().volume > 0.0f)
        {
            GetComponent<AudioSource>().volume -= 0.02f;
            yield return new WaitForEndOfFrame();
        }

        GetComponent<AudioSource>().Pause();
    }

    IEnumerator FadeAudioIn()
    {
        gameObject.GetComponent<AudioSource>().volume = 0;
        GetComponent<AudioSource>().Play();
        while (GetComponent<AudioSource>().volume < 1.0f)
        {
            GetComponent<AudioSource>().volume += 0.05f;
            yield return new WaitForEndOfFrame();
        }  
    }
	// Update is called once per frame
	void Update () {
	
	}
}
