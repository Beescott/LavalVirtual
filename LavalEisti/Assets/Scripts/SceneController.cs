using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private static SceneController singleton = null;

    public GameObject VFXContainer;

    public Vector3 spawnPoint;
    public GameObject playerPrefab;

    private GameObject player;

    public static bool IsRightHand = false;
    public static bool IsLeftHand = false;
    public static bool IsRightForeArm = false;
    public static bool IsLeftForeArm = false;

    public Material highlightMaterial;

    // Start is called before the first frame update
    void Start()
    {
        if (singleton == null)
        {
            singleton = this;

            player = Instantiate(playerPrefab, transform);
            player.transform.position = spawnPoint;
            
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

    public static GameObject GetPlayer()
    {
        return singleton.player;
    }

    public static Material GetHighlightMaterial()
    {
        return singleton.highlightMaterial;
    }

}
