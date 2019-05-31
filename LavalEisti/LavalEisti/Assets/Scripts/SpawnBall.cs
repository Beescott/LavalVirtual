using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{

    public GameObject Ball;
    public GameObject ballSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Ball.gameObject.name);
    }

    public void spawnNewBall()
    {
        GameObject newBall = Instantiate(Ball, ballSpawn.transform.position, Quaternion.identity);
        newBall.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 100));
    }
}
