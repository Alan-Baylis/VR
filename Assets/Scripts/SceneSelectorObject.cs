using UnityEngine;
using System.Collections;



public class SceneSelectorObject : MonoBehaviour
{


    public void ChangeContext(string text)
    {
        GetComponent<TextMesh>().text = text;
        GetComponentInChildren<ParticleSystem>().Play();
        GetComponent<SceneSelectorPortalChanger>().ChangePortalAppearance();
    }


    public void DisableSystem()
    {
        GetComponent<TextMesh>().text = "";
        GetComponentInChildren<ParticleSystem>().Stop();
    }

}