using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBallBehavior : ThrowableObject
{
    public Vector3 playerPosition;

    public GameObject BallSpawner;

    private Vector3 startPosition;

    private Rigidbody rb;

    private bool destroyed = false;
  
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
 

    // Start is called before the first frame update
    protected override void OnStart()
    {
        base.OnStart();
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "VoidRoom" && !destroyed)
        {
            destroyed = true;
            DestroyAndInstantiate();
        }
    }

    public override void OnRelease()
    {
        base.OnRelease();
        StartCoroutine(tempoDestroy());
    }
    IEnumerator tempoDestroy()
    {
        yield return new WaitForSeconds(10.0f);
        DestroyAndInstantiate();
    }
}
