using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text word;
    public KeelSystem ks;
    int scoretot = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        word.text = "SCORE : " + scoretot;
    }

    public void addScore()
    {
        int nb = 0;
        for (int i = 0; i < ks.keels.Count; i++)
        {
            if (ks.keels[i].GetComponent<KeelController>().hasMoved)
                nb++;
        }
        scoretot += nb;
    }
}
