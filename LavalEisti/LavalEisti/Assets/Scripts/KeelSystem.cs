using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeelSystem : MonoBehaviour
{
    public GameObject organizer;
    public List<GameObject> keels;
    public List<Vector3> initPos;
    public List<Quaternion> initRot;
    bool hasMoved = false;
    bool startTempo = false;
    public GameObject sol;
    public float tempoTime = 8.0f;
    public Transform A;
    public Transform B;
    public float speedOrganiser = 2.0f;
    public UIController ui;
    int nbPinMoved = 0;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < keels.Count; i++)
        {
            initPos.Add(keels[i].transform.position);
            initRot.Add(keels[i].transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < keels.Count; i++)
        {
            if (keels[i].GetComponent<KeelController>().hasMoved)
            {
                hasMoved = true;
                nbPinMoved++;
            }
        }
        if (hasMoved && !startTempo)
        {
            startTempo = true;
            StartCoroutine(restart());
            StartCoroutine(goDown());
        }
    }

    public IEnumerator goDown()
    {
        yield return new WaitForSeconds(tempoTime - 3.0f);
        //while (Vector3.Distance(organizer.transform.position, B.transform.position) >= 0.1f)
        StartCoroutine(goDownStepByStep());
    }
    public IEnumerator goDownStepByStep()
    {
        while (Vector3.Distance(organizer.transform.position, B.transform.position) >= 0.1f)
        {
            float step = speedOrganiser * Time.deltaTime; // calculate distance to move
            organizer.transform.position = Vector3.Lerp(organizer.transform.position, B.transform.position, step);
            yield return null;
        }
        StartCoroutine(goUp());
    }

    public IEnumerator goUp()
    {
        yield return new WaitForSeconds(2.0f);
        //while (Vector3.Distance(organizer.transform.position, B.transform.position) >= 0.1f)
        StartCoroutine(goUpStepByStep());
    }

    public IEnumerator goUpStepByStep()
    {
        while (Vector3.Distance(organizer.transform.position, A.transform.position) >= 0.1f)
        {
            float step = speedOrganiser * Time.deltaTime; // calculate distance to move
            organizer.transform.position = Vector3.Lerp(organizer.transform.position, A.transform.position, step);
            yield return null;
        }

    }

    public IEnumerator restart()
    {
        yield return new WaitForSeconds(tempoTime);
        if (hasMoved)
        {
            for (int i = 0; i < keels.Count; i++)
            {
                keels[i].transform.position = initPos[i];
                keels[i].transform.rotation = initRot[i];
                keels[i].GetComponent<Rigidbody>().velocity = Vector2.zero;
                keels[i].GetComponent<Rigidbody>().isKinematic = true;
            }
        }
        StartCoroutine(immobilise());
    }
    public IEnumerator immobilise()
    {
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < keels.Count; i++)
        {
            keels[i].GetComponent<Rigidbody>().isKinematic = false;
        }
        startTempo = false;
        hasMoved = false;
        nbPinMoved = 0;
    }
}
