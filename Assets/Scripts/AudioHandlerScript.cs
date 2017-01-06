using UnityEngine;
using System.Collections;

public class AudioHandlerScript : MonoBehaviour
{

    static AudioSource[] sources;

    // Use this for initialization
    void Start()
    {
        if (sources == null || sources.Length == 0)
        {
            //Get every single audio sources in the scene.
            sources = GameObject.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            Debug.Log("Sources initialized");
        }

    }
    // Update is called once per frame
    void Update()
    {

    }


    public void StopOtherNarratives(string current)
    {
        foreach (AudioSource audioSource in sources)
        {
            Debug.Log(audioSource.name);
            if (audioSource.isPlaying && audioSource.outputAudioMixerGroup.name == "Narrative" && audioSource.name != current)
            {
                audioSource.Stop();
            }
        }
    }
}
