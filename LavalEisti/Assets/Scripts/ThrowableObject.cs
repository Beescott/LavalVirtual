using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObject : GrabableObject
{
    protected static int NUMBEROFPOSITIONSAVED = 5;
    
    public float releasedThreshold;
    public float forceFactor;
    // Store 5 positions in order to know if the object must be released
    protected List<Vector3> savedPositions;

    protected override void OnStart()
    {
        savedPositions = new List<Vector3>();
    }

    public override void OnRelease()
    {
        GetComponentInChildren<Rigidbody>().isKinematic = false;
        Vector3 ballForce = savedPositions[NUMBEROFPOSITIONSAVED - 1] - savedPositions[0];
        GetComponentInChildren<Rigidbody>().AddForce(ballForce * forceFactor);
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

    // To call on Update of throwable objects
    protected void TestThrown()
    {
        // We look at the differences of two by two positions of savedPositions
        // if all differences are superior to threshold, then the ball is released.
        // We only want to release the ball after a big gesture
        if (amputedHand != null)
        {
            if (savedPositions.Count == NUMBEROFPOSITIONSAVED)
            {
                float movementSpeed = 0.0f;
                for (int i = 1; i < NUMBEROFPOSITIONSAVED; i++)
                {
                    movementSpeed += Vector3.Distance(savedPositions[i - 1], savedPositions[i]);
                }

                if (movementSpeed > releasedThreshold)
                {
                    amputedHand.AskToBeReleased();
                }
            }
        }
    }
}
