using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBehavior : ThrowableObject
{
    public bool isGrabbed;

    private Rigidbody rb;

    // Start is called before the first frame update
    protected override void OnStart()
    {
        base.OnStart();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        Debug.Log(go.name);
        // If the object is cutable
        if (go.GetComponent<ICutable>() != null)
        {
            Debug.Log("Cutable object");
            go.GetComponent<ICutable>().OnCut();
        }
    }

    public override void OnRelease()
    {
        if (isGrabbed)
        {
            rb.isKinematic = false;
            base.OnRelease();
            
            GameObject go = gameObject.transform.GetChild(0).gameObject;
            go.GetComponent<MeshCollider>().isTrigger = false;
            isGrabbed = false;
        }
    }

    public override void OnGrab()
    {
        if (!isGrabbed)
        {
            rb.isKinematic = true;
            GameObject go = gameObject.transform.GetChild(0).gameObject;
            go.GetComponent<MeshCollider>().isTrigger = true;
            isGrabbed = true;
            rb.velocity = Vector3.zero;
        }
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    GameObject go = collision.gameObject;
    //    Debug.Log(go.name);
    //    // If the object is cutable
    //    if (go.GetComponent<ICutable>() != null)
    //    {
    //        Debug.Log("Cutable object");
    //        go.GetComponent<ICutable>().OnCut();
    //    }
    //}
}
