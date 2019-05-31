using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareGrabbingCollider : MonoBehaviour
{
    public AmputedHand hand;

    List<GameObject> lstColliding = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.gameObject.CompareTag("GrabableObject") && !lstColliding.Contains(collider.transform.gameObject) && collider.transform.gameObject.GetComponentInParent<GrabableObject>() != null)
        {
            hand.PrepareToGrab(collider.transform.gameObject);
            lstColliding.Add(collider.transform.gameObject);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (lstColliding.Contains(collider.transform.gameObject))
        {
            lstColliding.Remove(collider.transform.gameObject);
            if (lstColliding.Count == 0)
            {
                hand.UnprepareToGrab(collider.transform.gameObject);
            }
            else
            {
                hand.PrepareToGrab(lstColliding[0]);
            }
        }
    }
}
