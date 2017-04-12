using UnityEngine;
using System.Collections;

public class DudesAtTheBenchBehaviour : MonoBehaviour
{

    public Transform runTo;

    public GameObject dude1;
    public GameObject dude2;
    public GameObject dude3;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") {
            Debug.Log("Player entered the trigger.");
            NavMeshAgent[] agents = GetComponentsInChildren<NavMeshAgent>();
            Animator[] animators = GetComponentsInChildren<Animator>();

            for(int i = 0; i < agents.Length; ++i)
            {
                Debug.Log("Destination set.");
                agents[i].destination = runTo.position;
                animators[i].SetBool("move", true);
            }
        }

        StartCoroutine(DestroyDudes());
    }



    IEnumerator DestroyDudes()
    {
        yield return new WaitForSecondsRealtime(8f);
        Destroy(dude1);
        Destroy(dude2);
        Destroy(dude3);
    }
}
