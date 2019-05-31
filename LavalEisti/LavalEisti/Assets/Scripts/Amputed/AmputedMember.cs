using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AmputedMember : MonoBehaviour
{
    public GameObject arm;
    public GameObject hand;

    public bool onHand = false;
    public bool onArm = false;
    public Vector3 offset = Vector3.zero;

    public float lengthArm = 27.0f;
    public float distancePointing = 3.0f;

    public Vector3 standardOffsetHand;
    public Vector3 standardOffsetArm;

    public Vector3 rotationHand;
    public Vector3 rotationArm;

    AmputedArm amputedArm = null;
    AmputedHand amputedHand = null;
    static Dictionary<GameObject, int> pointedObjects = new Dictionary<GameObject, int>();
    List<GameObject> lastPointedObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        if (!onHand && !onArm)
        {
            Debug.LogError("Need to set onHand or onArm for the AmputedMember");
        }
        else if (onHand && onArm)
        {
            Debug.LogError("Need to set only one of onHand or onArm for the AmputedMember");
        }

        if (offset == Vector3.zero)
        {
            offset = (onHand) ? standardOffsetHand : standardOffsetArm;
        }

        if (onHand)
        {
            GameObject h = Instantiate(hand, transform);
            h.GetComponentInChildren<Transform>().localPosition = Vector3.zero;
            h.GetComponent<AmputedHand>().VRHand = transform;

            amputedHand = h.GetComponent<AmputedHand>();
        }
        else if (onArm)
        {
            GameObject a = Instantiate(arm, transform);
            GameObject h = Instantiate(hand, a.transform);
            h.GetComponent<AmputedHand>().VRHand = transform;

            amputedArm = a.GetComponent<AmputedArm>();
            amputedHand = h.GetComponent<AmputedHand>();
        }

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler((onHand) ? rotationHand : rotationArm);
    }

    void Update()
    {
        Debug.DrawRay(transform.position, distancePointing * transform.right);
        Debug.DrawRay(transform.position + 0.05f * transform.forward, distancePointing * transform.right);
        Debug.DrawRay(transform.position - 0.05f * transform.forward, distancePointing * transform.right);
        Debug.DrawRay(transform.position + 0.05f * transform.up, distancePointing * transform.right);
        Debug.DrawRay(transform.position - 0.05f * transform.up, distancePointing * transform.right);

        RaycastHit[] hits = Physics.CapsuleCastAll(transform.position, transform.position + distancePointing * transform.right, 0.05f, transform.right);
        List<GameObject> newPointedObjects = new List<GameObject>();
        foreach (RaycastHit r in hits)
        {
            GameObject go = r.transform.gameObject;
            if (go.CompareTag("GrabableObject"))
            {
                newPointedObjects.Add(go);
                if (!lastPointedObjects.Contains(go))
                {
                    if (!pointedObjects.ContainsKey(go))
                    {
                        go.GetComponent<GrabableObject>().OnPointed();
                        pointedObjects.Add(go, 1);
                    }
                    else
                    {
                        pointedObjects[go] = 2;
                    }
                }

                if (lastPointedObjects.Count > 0)
                    amputedHand.Point();
            }
        }

        foreach (GameObject go in lastPointedObjects)
        {
            if (!newPointedObjects.Contains(go))
            {
                if (pointedObjects[go] == 2)
                    pointedObjects[go] = 1;
                else
                    pointedObjects.Remove(go);
            }
        }
        
        lastPointedObjects = newPointedObjects;
    }
}
