using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinning : MonoBehaviour
{
    private bool rotating;
    private Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        rotating = true;
        destination = new Vector3(0, 180, 0);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
