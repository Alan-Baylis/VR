using UnityEngine;
using System.Collections;



public class SceneSelectorObject : MonoBehaviour
{


    public void ChangeContext(string text)
    {
        GetComponent<TextMesh>().text = text;
    }


    public void DisableSystem()
    {
        GetComponent<TextMesh>().text = "";
    }

}