using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeelController : MonoBehaviour
{
    public GameObject centre;
    public bool hasMoved = false;
    public float heightToGround;
    private Rigidbody rb;
    private Camera cam;
    private GameObject sol;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        sol = transform.parent.GetComponent<KeelSystem>().sol;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(centre.transform.position.y - sol.transform.position.y) < heightToGround)
        {
            hasMoved = true;
        }
        else
        {
            hasMoved = false;
        }
        /*if (Input.GetMouseButtonDown(0))
        {
            Vector3 direction = (centre.transform.position - cam.transform.position) / (centre.transform.position - cam.transform.position).magnitude;
            rb.AddForce(direction * 10.0f, ForceMode.Impulse);
        }*/
    }

    /*void OnColliderEnter(Collision collider)
    {
        Vector3 direction = (centre.transform.position - collider.transform.position) / (centre.transform.position - collider.transform.position).magnitude;
        rb.AddForce(direction * 10.0f, ForceMode.Impulse);
    }*/
}
