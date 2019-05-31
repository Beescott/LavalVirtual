using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltBehavior : MonoBehaviour
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
        if (Vector3.Dot(transform.up, Vector3.down) > 0.7f)
        {
            if (!ps.isPlaying)
                ps.Play();
        }
        else
        {
            if (ps.isPlaying)
            {
                ps.Stop();
            }
        }
    }
}
