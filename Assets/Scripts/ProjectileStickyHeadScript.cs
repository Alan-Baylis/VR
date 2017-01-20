using UnityEngine;
using System.Collections;

public class ProjectileStickyHeadScript : MonoBehaviour {

    public AudioClip impact;

    private bool playDelayed = false;

    //Add this to a projectile along with a box collider
    void Start()
    {
        if(GetComponent<Collider>() != null)
        {
            Debug.Log("You need a collider to use this script.");
        }
    }

    public string CollidingWithTag;

    void OnTriggerEnter(Collider hit)
    {
        Debug.Log(hit.GetComponent<Collider>().tag);
        if (hit.GetComponent<Collider>().tag == CollidingWithTag)
        {
            transform.parent.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }

        if(GetComponent<AudioSource>() != null && playDelayed == false)
        {
            GetComponent<AudioSource>().PlayOneShot(impact);
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        playDelayed = true;
        yield return new WaitForSeconds(1);
        playDelayed = false;

    }
}
