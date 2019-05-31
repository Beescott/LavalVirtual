using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabableObject : MonoBehaviour
{
    public AmputedHand amputedHand = null;
    public bool isGrabbed = false;

    protected virtual void OnStart() { }

    public virtual void OnGrab() {
        isGrabbed = true;
        Rigidbody[] rbs = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in rbs)
        {
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
        }
    }

    public virtual void OnRelease() {
        isGrabbed = false;
        Rigidbody[] rbs = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in rbs)
        {
            rb.isKinematic = false;
        }
    }

    public virtual void OnPointed()
    {
    }

    public virtual void OnPointedExit()
    {
    }

    // Start is called before the first frame update
    protected void Start()
    {
        this.tag = "GrabableObject";
        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.gameObject.tag = "GrabableObject";
        }
        OnStart();
    }
}
