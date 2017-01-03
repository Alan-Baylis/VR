using UnityEngine;
using System.Collections;

namespace VRTK
{
    public class Show_Details : VRTK.VRTK_InteractableObject
    {

        public GameObject Tooltip;
        private bool isShown = false;

        protected override void Start()
        {
            Tooltip.GetComponent<CanvasGroup>().alpha = 0;
            Tooltip.transform.Find("Teleport Button").GetComponent<Renderer>().enabled = false;
        }

        public override void OnInteractableObjectUsed(InteractableObjectEventArgs e)
        {
            base.OnInteractableObjectUsed(e);
            Debug.Log("Clicked item");
            if (isShown)
            {
                StartCoroutine(FadeOut());
                isShown = false;
                if(GetComponent<AudioSource>())
                {
                    GetComponent<AudioSource>().Stop();
                }

            }
            else
            {
                CloseOtherTooltips();
                string name = Tooltip.name;

                //Positions the billboard according to player height
                GameObject camera = GameObject.FindWithTag("MainCamera");
                float x = Tooltip.GetComponent<Transform>().position.x;
                float z = Tooltip.GetComponent<Transform>().position.z;
                Debug.Log("Transform: ");
                Debug.Log(x);
                Debug.Log(camera.GetComponent<Transform>().position.y);
                Debug.Log(z);
                Vector3 NewPosition = new Vector3(x, (camera.GetComponent<Transform>().position.y - 0.05f), z);
                Tooltip.GetComponent<Transform>().position = NewPosition;
                StartCoroutine(FadeIn());
                isShown = true;

                if (GetComponent<AudioSource>())
                {
                    GetComponent<AudioSource>().Play();
                }

            }

        }

        public void CloseThisTooltip()
        {
            if (isShown)
            {
                StartCoroutine(FadeOut());
                isShown = false;
                if(GetComponent<AudioSource>())
                {
                    GetComponent<AudioSource>().Stop();
                }

                
            }
        }

        void CloseOtherTooltips()
        {
            GameObject[] openTooltips = GameObject.FindGameObjectsWithTag("Tooltips");

            foreach (GameObject element in openTooltips)
            {
                if (element == gameObject)
                {
                    continue;
                }
                else
                {
                    element.GetComponent<Show_Details>().CloseThisTooltip();
                }
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
            Tooltip.transform.Find("Teleport Button").GetComponent<Renderer>().enabled = true;
            Tooltip.transform.Find("Teleport Button").GetComponent<Collider>().enabled = true;
        }

        IEnumerator FadeOut()
        {
            float alpha = 1.0f;
            float lerp = 0.0f;

            Tooltip.transform.Find("Teleport Button").GetComponent<Renderer>().enabled = false;
            Tooltip.transform.Find("Teleport Button").GetComponent<Collider>().enabled = false;
            while (Tooltip.GetComponent<CanvasGroup>().alpha != 0)
            {
                lerp = Mathf.MoveTowards(lerp, 5, 0.02f);
                alpha = Mathf.Lerp(1.0f, 0.0f, lerp);
                Tooltip.GetComponent<CanvasGroup>().alpha = alpha;
                yield return new WaitForEndOfFrame();
            }
            
        }
    }
}