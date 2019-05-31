using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private static SceneController singleton = null;

    public GameObject VFXContainer;

    // Start is called before the first frame update
    void Start()
    {
        if (singleton == null)
        {
            singleton = this;

            // INIT HERE
        }
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    // Get the instance of the SceneController
    public static SceneController GetInstance()
    {
        return singleton;
    }

    // Get the GameObject container of everything
    public static GameObject GetContainer()
    {
        return singleton.gameObject;
    }

    public static GameObject GetVFXContainer()
    {
        return singleton.VFXContainer;
    }

}
