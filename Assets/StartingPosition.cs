using UnityEngine;

public class StartingPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int pos = (int) DataStore.getValue("road_position", 1);
        Transform playerSpawn = this.transform.Find("Position_" + pos);

        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = playerSpawn.position;

        if(pos != 1)
        {
            GameObject.FindWithTag("Dudes").SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
