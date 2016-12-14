using UnityEngine;
using System.Collections;

namespace VRTK
{
    public class AudioTriggerShowInfoBillboard : MonoBehaviour
    {

        public GameObject Tooltip;
        private bool isShown = false;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter(Collider other)
        {
            if (other.GetComponentInParent<VRTK_PlayerObject>().objectType == VRTK_PlayerObject.ObjectTypes.Headset)
            {
                StartCoroutine(FadeIn());
            }
        }

        IEnumerator FadeIn()
        {
            float alpha = 0.0f;
            float lerp = 0.0f;

            while (Tooltip.GetComponent<CanvasGroup>().alpha != 1)
            {
                lerp = Mathf.MoveTowards(lerp, 5, 0.02f);
                alpha = Mathf.Lerp(0.0f, 1.0f, lerp);
                Tooltip.GetComponent<CanvasGroup>().alpha = alpha;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}