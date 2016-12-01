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
        }

        override public void StartTouching(GameObject currentTouchingObject)
        {
            if (IsTouched())
            {
                return;
            }
            if (!touchingObjects.Contains(currentTouchingObject))
            {
                touchingObjects.Add(currentTouchingObject);
                OnInteractableObjectTouched(SetInteractableObjectEvent(currentTouchingObject));

                if (isShown)
                {
                    StartCoroutine(FadeOut());
                    isShown = false;

                }
                else
                {
                    CloseOtherTooltips();
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

                }
            }
        }

        public void CloseThisTooltip()
        {
            if (isShown)
            {
                StartCoroutine(FadeOut());
                isShown = false;
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
        }

        IEnumerator FadeOut()
        {
            float alpha = 1.0f;
            float lerp = 0.0f;

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