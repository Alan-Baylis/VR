using UnityEngine;
using System.Collections;

public class SceneSelectorPortalChanger : MonoBehaviour {

    public Material PortalPic;
    public string SceneReference;



    public void ChangePortalAppearance()
    {
        GameObject.FindGameObjectWithTag("Portal").GetComponent<Renderer>().material = PortalPic;
    }


    void ChangeTeleporter()
    {
        
    }

}
