using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmputedHand : MonoBehaviour
{
    public enum HandState { Resting, Pointing, PreparingToGrab, Grabbing, Releasing };

    public float speedTorque;

    public bool onArm = false;

    public Transform VRHand;

    public HandState state = HandState.Resting;

    public HandSign noneSign;
    public HandSign restSign;
    public HandSign pointSign;
    public HandSign prepareToGrabSign;
    public HandSign grabSign;
    public HandSign releaseSign;

    public List<Transform> m_rotations;

    public GrabableObject grabbedObject = null;

    // Start is called before the first frame update
    void Start()
    {
        //saveRotationsIn(grabSign);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.A))
        {
            loadRotations(noneSign);
        }*/
        if (state == HandState.Resting)//(Input.GetKey(KeyCode.Z))
        {

            loadRotations(restSign);
        }
        if (state == HandState.Pointing)//(Input.GetKey(KeyCode.E))
        {
            loadRotations(pointSign);
        }
        if (state == HandState.PreparingToGrab)//(Input.GetKey(KeyCode.R))
        {
            loadRotations(prepareToGrabSign);
        }
        if (state == HandState.Grabbing)//(Input.GetKey(KeyCode.T))
        {
            loadRotations(grabSign);
        }
        if (state == HandState.Releasing)
        {
            loadRotations(restSign);
        }
    }

    void saveRotationsIn(HandSign h)
    {
        h.wristRotation = m_rotations[0].localRotation;
        //THUMB
        h.thumbRotation.phalange1 = m_rotations[1].localRotation;
        h.thumbRotation.phalange2 = m_rotations[2].localRotation;
        h.thumbRotation.phalange3 = m_rotations[3].localRotation;
        //INDEX
        h.indexRotation.phalange1 = m_rotations[4].localRotation;
        h.indexRotation.phalange2 = m_rotations[5].localRotation;
        h.indexRotation.phalange3 = m_rotations[6].localRotation;
        //MIDDLE
        h.middleRotation.phalange1 = m_rotations[7].localRotation;
        h.middleRotation.phalange2 = m_rotations[8].localRotation;
        h.middleRotation.phalange3 = m_rotations[9].localRotation;
        //RING
        h.ringRotation.phalange1 = m_rotations[10].localRotation;
        h.ringRotation.phalange2 = m_rotations[11].localRotation;
        h.ringRotation.phalange3 = m_rotations[12].localRotation;
        //PINKY
        h.pinkyRotation.phalange1 = m_rotations[13].localRotation;
        h.pinkyRotation.phalange2 = m_rotations[14].localRotation;
        h.pinkyRotation.phalange3 = m_rotations[15].localRotation;
    }

    void loadRotations(HandSign h)
    {
        if (onArm)
            m_rotations[0].localRotation = Quaternion.RotateTowards(m_rotations[0].localRotation, h.wristRotation, speedTorque/2f);
        else
            m_rotations[0].localRotation = Quaternion.Euler(0f, 0f, 0f);
        //THUMB
        m_rotations[1].localRotation = Quaternion.RotateTowards(m_rotations[1].localRotation, h.thumbRotation.phalange1, speedTorque);
        m_rotations[2].localRotation = Quaternion.RotateTowards(m_rotations[2].localRotation, h.thumbRotation.phalange2, speedTorque);
        m_rotations[3].localRotation = Quaternion.RotateTowards(m_rotations[3].localRotation, h.thumbRotation.phalange3, speedTorque);
        //INDEX
        m_rotations[4].localRotation = Quaternion.RotateTowards(m_rotations[4].localRotation, h.indexRotation.phalange1, speedTorque);
        m_rotations[5].localRotation = Quaternion.RotateTowards(m_rotations[5].localRotation, h.indexRotation.phalange2, speedTorque);
        m_rotations[6].localRotation = Quaternion.RotateTowards(m_rotations[6].localRotation, h.indexRotation.phalange3, speedTorque);
        //MIDDLE
        m_rotations[7].localRotation = Quaternion.RotateTowards(m_rotations[7].localRotation, h.middleRotation.phalange1, speedTorque);
        m_rotations[8].localRotation = Quaternion.RotateTowards(m_rotations[8].localRotation, h.middleRotation.phalange2, speedTorque);
        m_rotations[9].localRotation = Quaternion.RotateTowards(m_rotations[9].localRotation, h.middleRotation.phalange3, speedTorque);
        //RING
        m_rotations[10].localRotation = Quaternion.RotateTowards(m_rotations[10].localRotation, h.ringRotation.phalange1, speedTorque);
        m_rotations[11].localRotation = Quaternion.RotateTowards(m_rotations[11].localRotation, h.ringRotation.phalange2, speedTorque);
        m_rotations[12].localRotation = Quaternion.RotateTowards(m_rotations[12].localRotation, h.ringRotation.phalange3, speedTorque);
        //PINKY
        m_rotations[13].localRotation = Quaternion.RotateTowards(m_rotations[13].localRotation, h.pinkyRotation.phalange1, speedTorque);
        m_rotations[14].localRotation = Quaternion.RotateTowards(m_rotations[14].localRotation, h.pinkyRotation.phalange2, speedTorque);
        m_rotations[15].localRotation = Quaternion.RotateTowards(m_rotations[15].localRotation, h.pinkyRotation.phalange3, speedTorque);
    }

    /*public void TriggerGrabbingCollider(GameObject go)
    {
        if (state != HandState.Grabbing && state != HandState.Releasing)
        {
            Grab(go);
        }
    }

    public void TriggerPrepareGrabbingCollider(GameObject go)
    {
        if (state != HandState.Grabbing && state != HandState.Releasing)
        {
            PrepareToGrab(go);
        }
    }*/

    public void SetOnArm()
    {
        onArm = true;
    }

    public void AskToBeReleased()
    {
        Release();
    }

    public void Point()
    {
        if (state == HandState.Resting)
        {
            Debug.Log("HAND POINTING");

            state = HandState.Pointing;
        }
    }

    public void NotPoint()
    {
        if (state == HandState.Pointing)
        {
            Debug.Log("HAND STOP POINTING");

            state = HandState.Resting;
        }
    }

    public void PrepareToGrab(GameObject go)
    {
        if (state != HandState.Grabbing && state != HandState.PreparingToGrab && state != HandState.Releasing)
        {
            Debug.Log("PREPARING TO GRAB");

            state = HandState.PreparingToGrab;
        }
    }

    public void UnprepareToGrab(GameObject go)
    {
        if (state == HandState.PreparingToGrab)
        {
            Debug.Log("UNPREPARING TO GRAB");
            state = HandState.Resting;

            if (VRHand.GetComponent<AmputedMember>().IsPointing())
            {
                Point();
            }
        }
    }

    public void Grab(GameObject go)
    {
        if (state != HandState.Releasing && state != HandState.Grabbing && !go.GetComponentInParent<GrabableObject>().isGrabbed)
        {
            state = HandState.Grabbing;

            grabbedObject = go.GetComponentInParent<GrabableObject>();
            Debug.Log("GRABBING");

            grabbedObject.amputedHand = this;
            grabbedObject.transform.SetParent(transform);
            grabbedObject.isGrabbed = true;
            grabbedObject.OnGrab();
        }
    }

    public void Release()
    {
        if (state != HandState.Releasing)
        {
            state = HandState.Resting;

            Debug.Log("RELEASING");

            grabbedObject.amputedHand = null;
            grabbedObject.transform.SetParent(SceneController.GetContainer().transform);
            grabbedObject.isGrabbed = false;
            grabbedObject.OnRelease();
            grabbedObject = null;

            //state = HandState.Releasing;
        }
    }
}

[System.Serializable]
public class HandSign
{
    public Quaternion wristRotation;
    public FingerRotations thumbRotation = new FingerRotations();
    public FingerRotations indexRotation = new FingerRotations();
    public FingerRotations middleRotation = new FingerRotations();
    public FingerRotations ringRotation = new FingerRotations();
    public FingerRotations pinkyRotation = new FingerRotations();
}

[System.Serializable]
public class FingerRotations
{
    public Quaternion phalange1;
    public Quaternion phalange2;
    public Quaternion phalange3;
}