using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

namespace VRTK
{
    public class SplashScreen : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            StartCoroutine(MoveToNextScene());
        }

        // Update is called once per frame
        void Update()
        {

        }

        IEnumerator MoveToNextScene()
        {
            yield return new WaitForSeconds(5);
            GetComponent<SteamVR_LoadLevel>().Trigger();

        }
    }
}