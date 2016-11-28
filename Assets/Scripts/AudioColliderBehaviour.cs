﻿using UnityEngine;
using System.Collections;
namespace VRTK
{
    public class AudioColliderBehaviour : MonoBehaviour
    {

        [Tooltip("Use with caution: evaluates only, if player has entered the volume.")]
        public bool playsOnlyOnce = false;
        [Tooltip("Should the playback be continued on exit?")]
        public bool pauseOnExit = false;
        [Tooltip("Hide this trigger on collision?")]
        public bool hideOnTrigger = false;


        private bool hasBeenPlayed = false;



        // Use this for initialization
        void Start()
        {

        }

        void OnTriggerEnter(Collider other)
        {
            if (other.GetComponentInParent<VRTK_PlayerObject>().objectType == VRTK_PlayerObject.ObjectTypes.Headset)
            {
                if (playsOnlyOnce && !hasBeenPlayed)
                {
                    StartCoroutine(FadeAudioIn());
                    hasBeenPlayed = true;
                }
                else if (playsOnlyOnce && hasBeenPlayed)
                {
                    Debug.Log("Tämä pätkä soiteltiin jo.");
                }
                else
                {
                    StartCoroutine(FadeAudioIn());
                }


                if (hideOnTrigger)
                {
                    Renderer[] renderers = GetComponentsInChildren<Renderer>();

                    foreach (Renderer renderer in renderers)
                    {
                        renderer.enabled = false;
                    }
                }

            }
        }

        void OnTriggerExit(Collider other)
        {
            Debug.Log("Something exited the trigger volume.");
            if (pauseOnExit)
            {
                StartCoroutine(FadeAudioOut());
            }

        }

        IEnumerator FadeAudioOut()
        {
            while (GetComponent<AudioSource>().volume > 0.0f)
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
        void Update()
        {

        }
    }
}