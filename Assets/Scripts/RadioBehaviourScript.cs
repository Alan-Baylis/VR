using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class RadioBehaviourScript : MonoBehaviour {

    private string contentPath;
    private Object[] files;
    public AudioClip tuningSound;


    private AudioSource radioSource;
    private int indexOfNowPlaying;

	// Use this for initialization
	void Start () {
        files = Resources.LoadAll("Radio");
        radioSource = GetComponent<AudioSource>();
        if (files.Length != 0)
        {
            indexOfNowPlaying = -1;
            StartCoroutine("PlayNextMediaFile");     
        }
    }

    public void ChangeChannelManually()
    {
        StopCoroutine("PlayNextMediaFile");
        StartCoroutine("PlayNextMediaFile");
    }

    public void TurnRadioOff()
    {
        radioSource.Stop();
        StopCoroutine("PlayNextMediaFile");

    }

    public void TurnRadioOn()
    {
        StartCoroutine("PlayNextMediaFile");
    }
    IEnumerator PlayNextMediaFile()
    {
        //Keeps this going!
        while (true)
        {
            radioSource.Stop();

            //Plays tuning sound for a random while at random location

            float length = tuningSound.length;
            radioSource.clip = tuningSound;
            radioSource.time = Random.Range(0f, length - 6f);
            float random = Random.Range(2f, 6f);
            StartCoroutine(PlayForSeconds(random));
            Debug.Log("Playing tuning sound for: " + random);
            yield return new WaitForSeconds(random);

            //Now, let's play the next file
            Debug.Log("Playing Next file");
            AudioClip nextClip = getNextFile();
            radioSource.clip = nextClip;
            radioSource.time = 0;
            radioSource.Play();

            yield return new WaitForSeconds(nextClip.length);

        }
    }

    IEnumerator PlayForSeconds(float random)
    {
        radioSource.Play();
        yield return new WaitForSeconds(random);
        radioSource.Stop();

    }

    private AudioClip getNextFile()
    {
        //Source was just initialized; plays the first file on the queue
        if (indexOfNowPlaying == -1)
        {
            indexOfNowPlaying += 1;
            return (AudioClip)files[0];
        }

        if (indexOfNowPlaying == files.Length-1)
        {
            Debug.Log("Last, moving to first file.");
            indexOfNowPlaying = 0;
            return (AudioClip)files[0];
        } else
        {
            Debug.Log("Next file");
            int temp = indexOfNowPlaying;
            indexOfNowPlaying += 1;
            return (AudioClip)files[temp + 1];
        }

        
    }
}

