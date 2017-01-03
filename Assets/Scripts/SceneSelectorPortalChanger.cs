using UnityEngine;
using System.Collections;

public class SceneSelectorPortalChanger : MonoBehaviour
{

    public string SceneName;


    public void ChangePortalAppearance(string text)
    {
        GameObject.FindGameObjectWithTag("Portal").GetComponentInChildren<SceneSelectorObject>().ChangeContext(name);
    }


    public void ChangeTeleporter()
    {
        GameObject.FindGameObjectWithTag("Portal").GetComponent<SteamVR_LoadLevel>().levelName = SceneName;
    }

}
