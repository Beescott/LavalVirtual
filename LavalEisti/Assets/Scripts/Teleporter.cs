using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MenuObject
{
    public override void Trigger()
    {
        SceneController.GetPlayer().transform.position = new Vector3(transform.position.x, SceneController.GetInstance().spawnPoint.y, transform.position.z);    }
}
