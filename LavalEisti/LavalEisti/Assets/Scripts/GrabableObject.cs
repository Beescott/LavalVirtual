using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabableObject : MonoBehaviour
{
    public AmputedHand amputedHand;

    protected virtual void OnStart() { }

    public virtual void OnGrab() { }

    public virtual void OnRelease() { }
    public virtual void OnPointed() { }

    // Start is called before the first frame update
    protected void Start()
    {
        this.tag = "GrabableObject";
        OnStart();
    }
}
