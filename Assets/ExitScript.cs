using UnityEngine;
using System.Collections;
using VRTK;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour {

    public string SceneName;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<VRTK_PlayerObject>().objectType == VRTK_PlayerObject.ObjectTypes.Headset)
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
