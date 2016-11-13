using UnityEngine;
using System.Collections;
using System;

public class Movement : MonoBehaviour
{
    Animator animator; //stores the animator component
    float v; //vertical movements
    float h; //horizontal movements
    float sprint;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>(); //assigns Animator component when we start the game

        Debug.Log("From Start. This is " + gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void FixedUpdate()
    {

        // set paramaeters
        animator.SetFloat("Run", sprint);
        animator.SetFloat("Turn", h);
        animator.SetFloat("Walk", v);
        
        Debug.Log(gameObject.name + " Walk: " + v + ", Turn: " + h + ", Run: " + sprint);

    }

    void movement()
    {
        switch (gameObject.name)
        {

            case "Generic_Human":
                sprint = 1;
                v = 1;
                h = -1;
                break;

            case "Generic_Human (1)":
                sprint = 0.0f;
                v = 1;
                h = 1;
                break;

            case "Generic_Human (2)":
                v = 0;
                h = 0;
                sprint = 0.0f;
                break;
        }
    }
}
