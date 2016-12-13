using UnityEngine;
using System.Collections;

public class SceneSelectorPortalChanger : MonoBehaviour {

    public Material PortalPic;
    public string SceneName;



    public void ChangePortalAppearance(string text)
    {
        GameObject.FindGameObjectWithTag("SceneSelector").GetComponentInChildren<SceneSelectorObject>().ChangeContext(name); 
        GameObject.FindGameObjectWithTag("Portal").GetComponent<Renderer>().material = PortalPic;
    }


    public void ChangeTeleporter()
    {
        GameObject.FindGameObjectWithTag("Portal").GetComponent<SteamVR_LoadLevel>().levelName = SceneName;
    }

}
