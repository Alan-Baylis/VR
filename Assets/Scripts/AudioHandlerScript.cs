using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AudioHandlerScript : MonoBehaviour
{
    public GameObject prefab = null;

    private GameObject controller;
    private GameObject counter;

    void Awake()
    {

        if (prefab != null)
        {
            controller = GameObject.Find("Controller (left)");
            counter = (GameObject)Instantiate(prefab, transform.position, transform.rotation);
            counter.transform.parent = controller.transform;
            //counter.transform.position = controller.transform.position;
        }

    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public AudioSource[] getAudioSources()
    {
        return GameObject.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
    }


    public void StopOtherNarratives(string current)
    {
        foreach (AudioSource audioSource in getAudioSources())
        {
            Debug.Log(audioSource.name);
            if (audioSource.isPlaying && audioSource.outputAudioMixerGroup.name == "Narrative" && audioSource.name != current)
            {
                audioSource.Stop();
            }
        }
    }

    // Function to know if narration is playing
    public bool IsNarrationPlaying()
    {
        foreach (AudioSource audioSource in getAudioSources())
        {
            if (audioSource.isPlaying && audioSource.outputAudioMixerGroup.name == "Narrative")
            {
                return true;
            }
        }

        return false;
    }

    // Function to get current time / lenght in string format
    public string Duration()
    {
        if (IsNarrationPlaying())
        {
            return string.Format("{0:0.#}s / {1:0.#}s", PlayingSource().time, PlayingSource().clip.length);
        }

        return "";
    }

    // Get the source playing narration
    private AudioSource PlayingSource()
    {
        foreach (AudioSource audioSource in getAudioSources())
        {
            if (audioSource.isPlaying && audioSource.outputAudioMixerGroup.name == "Narrative")
            {
                return audioSource;
            }
        }

        return new AudioSource();
    }
}
