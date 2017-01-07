using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VRTK;

public class NewspaperHandler : MonoBehaviour {

    // Variables for all the children and current top
    private Queue<GameObject> children;
    private GameObject topPaper;


    // On Awake
    void Awake()
    {
        // Let's get the children
        List<GameObject> temp = new List<GameObject>();

        foreach (Transform child in transform)
        {
            child.GetComponent<Rigidbody>();
            temp.Add(child.gameObject);
        }

        // Guarantee same order everytime
        temp = temp.OrderBy(obj => obj.name).Reverse().ToList();

        children = new Queue<GameObject>(temp);

    }

	// Use this for initialization
	void Start () {
        // Activate
        if (children.Count > 0)
        {
            ActivatePaper();
        }
        
	}

    // When something exit the trigger
    void OnTriggerExit(Collider other)
    {
        // Make new top paper active when previous leaves trigger zone
        if (topPaper == other.gameObject)
        {
            if (children.Count > 0)
            {
                ActivatePaper();
            }
        }
    }

    // Function to make topmost paper active
    void ActivatePaper()
    {
        // Assign top most newspaper
        topPaper = children.Dequeue();
        
        // Make newspaper non-kinematic
        topPaper.GetComponent<Rigidbody>().isKinematic = false;
        
        // Make newspaper grabbable
        topPaper.GetComponent<VRTK_InteractableObject>().isGrabbable = true;
    }
}
