using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KitchenMenu : MenuObject
{
    public override void Trigger()
    {
        SceneManager.LoadScene(1);
    }
}
