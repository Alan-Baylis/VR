using UnityEngine;
using System.Collections;

public class HitSound : MonoBehaviour {

    public AudioClip impact;
    public float velocity = 1.5f;

    void OnCollisionEnter(Collision hit)
    {
        if(GetComponent<Rigidbody>().velocity.magnitude >= velocity)
        {
            GetComponent<AudioSource>().PlayOneShot(impact);
        }
    }
}
