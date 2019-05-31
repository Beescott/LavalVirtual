using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuObject : GrabableObject
{
    public bool isPointed = false;
    public float timeThreshold = 3.0f;

    private float timePointed = 0.0f;

    // Start is called before the first frame update
    protected override void OnStart()
    {
        isGrabbed = true;
    }

    public override void OnPointed()
    {
        base.OnPointed();
        isPointed = true;
        timePointed = 0.0f;

        Material highlight = SceneController.GetHighlightMaterial();
        List<Material> materials;
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            materials = new List<Material>();
            materials.AddRange(renderer.materials);
            materials.Add(highlight);
            Material[] mats = new Material[materials.Count];
            for (int i = 0; i < materials.Count; i++)
                mats[i] = materials[i];
            renderer.materials = mats;
        }
    }
    

    public override void OnPointedExit()
    {
        base.OnPointedExit();
        isPointed = false;

        List<Material> materials;
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            materials = new List<Material>();
            materials.AddRange(renderer.materials);
            materials.RemoveAt(materials.Count - 1);
            renderer.materials = materials.ToArray();
        }
    }

    public virtual void Trigger()
    {

    }

    void Update()
    {
        if (isPointed)
        {
            timePointed += Time.deltaTime;

            if (timePointed >= timeThreshold)
            {
                timePointed = 0.0f;
                Trigger();
            }
        }
    }
}
