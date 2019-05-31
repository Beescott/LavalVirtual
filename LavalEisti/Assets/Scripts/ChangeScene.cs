using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void goToBowling()
    {
        SceneManager.LoadScene(0);
    }

    public void goToKitchen()
    {
        SceneManager.LoadScene(1);
    }
}
