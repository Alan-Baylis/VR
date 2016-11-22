using UnityEngine;
using System.Collections;

public class Fade_InOut : MonoBehaviour {

    public float duration = 1.0f;
    //This can be only 0 or 1
    public float startingAlpha = 1.0f;
    private float lerp = 0.0f;
    private float alpha = 0.0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        lerpAlpha();
	}

    void lerpAlpha()
    {
        //The alternative for a flashing object (thanks StackOverflow)
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        alpha = Mathf.Lerp(1.0f, 0.0f, lerp);
        /*lerp = Mathf.MoveTowards(lerp, duration, 0.0025f);
        if (startingAlpha > 0.95f)
        {
            alpha = Mathf.Lerp(1.0f, 0.0f, lerp);
        } else
        {
            alpha = Mathf.Lerp(0.0f, 1.0f, lerp);
        }
        */
        Color color = gameObject.GetComponent<Renderer>().material.color;
        color.a = alpha;
        gameObject.GetComponent<Renderer>().material.SetColor("_Color",color);
    }
}
