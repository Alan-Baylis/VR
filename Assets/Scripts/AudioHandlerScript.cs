using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AudioHandlerScript : MonoBehaviour
{

    private AudioSource[] sources;

    


    void Awake()
    {
    
            //Get every single audio sources in the scene.
            sources = GameObject.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            Debug.Log("Sources initialized");
        
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
