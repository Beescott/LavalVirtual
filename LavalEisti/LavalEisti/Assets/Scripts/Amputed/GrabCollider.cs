﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCollider : MonoBehaviour
{
    public AmputedHand hand;

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
        if (collider.transform.gameObject.CompareTag("GrabableObject"))
            hand.Grab(collider.transform.gameObject);
    }
}
