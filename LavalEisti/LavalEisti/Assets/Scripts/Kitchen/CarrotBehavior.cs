using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotBehavior : MonoBehaviour, ICutable
{
    public GameObject[] carrotBits = new GameObject[5];
    private int n = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnCut()
    {
        carrotBits[n].transform.SetParent(SceneController.GetContainer().transform);
        carrotBits[n].AddComponent<Rigidbody>();
        n++;

        if (n == 4)
        {
            carrotBits[n].transform.SetParent(SceneController.GetContainer().transform);
            carrotBits[n].AddComponent<Rigidbody>();
            Destroy(gameObject);
        }
    }
}
