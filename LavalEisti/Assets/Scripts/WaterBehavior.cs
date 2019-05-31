using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehavior : MonoBehaviour
{
    public ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        if (ps.isEmitting)
            ps.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Vector3.Dot(transform.up, Vector3.down) > 0.8f)
        //Debug.Log(transform.rotation.eulerAngles.x);
        if (transform.rotation.eulerAngles.x > 0.0f && transform.rotation.eulerAngles.x < 90.0f)
        {
            if (!ps.isPlaying)
            {
                ps.Play();
                transform.GetComponentInParent<SourceWaterController>().HaveWater = true;
            }
        }
        else
        {
            if (ps.isPlaying)
            {
                ps.Stop();
                ps.Clear();
                transform.GetComponentInParent<SourceWaterController>().HaveWater = false;
            }
        }
    }
}
