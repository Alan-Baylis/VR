using UnityEngine;
using System.Collections;



public class SceneSelectorObject : MonoBehaviour
{

    void Start ()
    {
        GetComponent<Renderer>().enabled = false;
    }
    public void ChangeContext(string text)
    {
        GetComponent<Renderer>().enabled = true;
        GetComponentInChildren<ParticleSystem>().Play();
        GetComponent<TextMesh>().text = text;
    }


    public void DisableSystem()
    {
        GetComponentInChildren<ParticleSystem>().Stop(); 
        GetComponent<TextMesh>().text = "";
        GetComponent<Renderer>().enabled = false;
    }

}