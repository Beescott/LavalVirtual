using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeController : GrabableObject
{
    private Rigidbody rb;
    public GameObject Door;
    private bool isOpen = false;
    public Transform DoorOpen;
    public Transform DoorClosed;
    public float speedOpen = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            OnGrab();
        }

        Transform target = isOpen ? DoorOpen : DoorClosed;
        Door.transform.rotation = Quaternion.RotateTowards(Door.transform.rotation, target.rotation, speedOpen * Time.deltaTime);
    }

    protected override void OnStart()
    {

    }

    public override void OnGrab()
    {
        isOpen = !isOpen;
        GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(tempoCollider());
    }

    IEnumerator tempoCollider()
    {
        yield return new WaitForSeconds(0.5f);
       GetComponent<BoxCollider>().enabled = true;
    }

    public override void OnRelease()
    {
        
    }

    public override void OnPointed()
    {

    }
}
