using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBallBehavior : ThrowableObject
{
    public bool isHeld;
    public bool isReleased;
    public float forceFactor;

    public Vector3 playerPosition;

    public GameObject BallSpawner;

    private Vector3 startPosition;

    private Rigidbody rb;
  
    void DestroyAndInstantiate()
    {
        GameObject newBall = Instantiate(gameObject, BallSpawner.transform.position, Quaternion.identity);
        newBall.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,50));
        Destroy(gameObject);
    }

    // TODO
    public override void OnPointed()
    {

    }

    public override void OnGrab()
    {
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
    }

    public override void OnRelease()
    {
        isReleased = true;
        rb.isKinematic = false;
        isHeld = false;
        Vector3 ballForce = savedPositions[NUMBEROFPOSITIONSAVED - 1] - savedPositions[0];
        rb.AddForce(ballForce * forceFactor);
    }

    // Start is called before the first frame update
    protected override void OnStart()
    {
        base.OnStart();
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        isHeld = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0,150,-800));
        }

        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = startPosition;
        }

        if (transform.position.y < -10.0f)
        {
            DestroyAndInstantiate();
        }
    }

    void FixedUpdate()
    {
        if (savedPositions.Count >= 5)
        {
            savedPositions.RemoveAt(0);
            savedPositions.Add(transform.position);
        }
        else
        {
            savedPositions.Add(transform.position);
        }
        TestThrown();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "VoidRoom")
        {
            DestroyAndInstantiate();
        }
    }
}
