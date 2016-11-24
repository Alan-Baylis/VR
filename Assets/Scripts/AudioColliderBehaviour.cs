using UnityEngine;
using System.Collections;
namespace VRTK {
    public class AudioColliderBehaviour : MonoBehaviour {

        [Tooltip("Use with caution: evaluates only, if player has entered the volume.")]
        public bool playsOnlyOnce = false;
        private bool hasBeenPlayed = false;

        private VRTK_HeadsetCollision collisiondetector;


        // Use this for initialization
        void Start()
        {
            collisiondetector = GameObject.FindGameObjectWithTag("CameraRig").GetComponent<VRTK_HeadsetCollision>();
            if(!collisiondetector)
            {
                Debug.Log("Audio: Collider initialization failed");
            }
            collisiondetector.HeadsetCollisionDetect += new HeadsetCollisionEventHandler(HeadsetCollision);
        }

        void HeadsetCollision(object sender, HeadsetCollisionEventArgs e) {

            Debug.Log("Headset detected");

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

        void OnTriggerExit(Collider other)
        {
            Debug.Log("Something exited the trigger volume.");
            StartCoroutine(FadeAudioOut());

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
        void Update() {

        }
    }
}