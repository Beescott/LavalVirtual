using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotBehavior : MonoBehaviour, ICutable
{
    public GameObject[] carrotBits = new GameObject[5];
    private int n = 0;

    // Update is called once per frame
    void Update()
    {
    }

    public void OnCut()
    {
        carrotBits[n].transform.SetParent(SceneController.GetContainer().transform);
        carrotBits[n].AddComponent<Rigidbody>();
        carrotBits[n].gameObject.tag = "GrabableObject";
        carrotBits[n].AddComponent<ThrowableObject>();
        carrotBits[n].AddComponent<FoodController>();
        carrotBits[n].GetComponent<ThrowableObject>().releasedThreshold = 0.15f;
        carrotBits[n].GetComponent<ThrowableObject>().forceFactor = 1000;
        n++;

        if (n == 4)
        {
            carrotBits[n].transform.SetParent(SceneController.GetContainer().transform);
            carrotBits[n].AddComponent<Rigidbody>();
            carrotBits[n].gameObject.tag = "GrabableObject";
            carrotBits[n].AddComponent<ThrowableObject>();
            carrotBits[n].AddComponent<FoodController>();
            carrotBits[n].GetComponent<ThrowableObject>().releasedThreshold = 0.15f;
            carrotBits[n].GetComponent<ThrowableObject>().forceFactor = 1000;
            Destroy(gameObject);
        }
    }
}
