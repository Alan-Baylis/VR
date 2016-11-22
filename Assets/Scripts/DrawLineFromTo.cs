using UnityEngine;
using System.Collections;

public class DrawLineFromTo : MonoBehaviour
{


    public Transform drawLineFrom;
    public Transform drawLineTo;

    // Use this for initialization
    void Start()
    {


    }


    // Update is called once per frame
    void Update()
    {

    }


    private void SetLineTransform()
    {
        if (drawLineFrom == null)
        {

            gameObject.GetComponent<LineRenderer>().SetPosition(0, drawLineFrom.position);
            gameObject.GetComponent<LineRenderer>().SetPosition(1, drawLineTo.position);

        }

    }


}

