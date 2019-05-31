using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmputedArm : MonoBehaviour
{
    public Transform posHand;

    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<AmputedHand>().transform.localPosition = posHand.localPosition;
        GetComponentInChildren<AmputedHand>().SetOnArm();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
