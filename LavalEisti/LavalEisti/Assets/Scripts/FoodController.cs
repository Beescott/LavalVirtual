using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : GrabableObject
{
    private Rigidbody rb;
    Vector3 lastVel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Thrown();
    }

    protected override void OnStart() 
    { 

    }

    public override void OnGrab() 
    {
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
    }

    public override void OnRelease() 
    {
        rb.isKinematic = false;
        rb.velocity = Vector3.zero;
    }

    public override void OnPointed()
    { 

    }

    public void Thrown()
    {
        if(rb.velocity != Vector3.zero)
        {
            OnGrab();
        }

        lastVel = rb.velocity;
    }
}
