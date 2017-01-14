using UnityEngine;
using System.Collections;

public class LensFlareDistanceScale : MonoBehaviour {

    GameObject player;
    LensFlare subject;

    // Public interface
    public float exponentiality = 1f;
    public float brightness = 1f;
    public float minimumBrightness = 0.1f;
    public float maximumDistance = 500f;

	// Use this for initialization
	void Start () {
	    player = GameObject.FindWithTag("Player");
        subject = this.GetComponent<LensFlare>();
        subject.fadeSpeed = brightness;
    }

    // Update is called once per frame
    void Update() {
        float distance = Vector3.Distance(player.transform.position, this.transform.position);
        float brightnessLevel = Mathf.Pow((brightness / distance), exponentiality);

        // If exponential value is smaller than minimum brightness, then minimum brightness is used and scaled to maximum distance.
        if (brightnessLevel < minimumBrightness) {
            brightnessLevel = Mathf.Max(0f, minimumBrightness * (maximumDistance - distance) / maximumDistance);
        }

        subject.brightness = brightnessLevel;
    }
}
