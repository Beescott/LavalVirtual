using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGlassController : MonoBehaviour
{
    // Water level100% = 1, 0% = 0
    public float levelWater = 0.0f;
    public GameObject waterObject;
    private Vector3 initScale;

    // Start is called before the first frame update
    void Start()
    {
        initScale = waterObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (levelWater > 1.0f)
            levelWater = 1.0f;

        if (levelWater < 0.01f)
            levelWater = 0.01f;

        waterObject.transform.localScale = new Vector3(initScale.x, initScale.y * levelWater, initScale.z);
    }
}
