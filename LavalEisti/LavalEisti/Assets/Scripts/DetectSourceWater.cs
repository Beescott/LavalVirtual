using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectSourceWater : MonoBehaviour
{
    bool isPouringWater = false;
    SourceWaterController swc;

    void Update()
    {
        if (isPouringWater && swc.HaveWater)
            transform.parent.GetComponent<WaterGlassController>().levelWater += swc.speedWater * Time.deltaTime;
    }
    public void OnTriggerEnter(Collider other)
    {
        swc = other.GetComponent<SourceWaterController>();
        if(swc != null)
        {
            isPouringWater = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        swc = other.GetComponent<SourceWaterController>();
        if (swc != null)
        {
            isPouringWater = false;
        }
    }
}
