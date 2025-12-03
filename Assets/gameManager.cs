using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Properties;

public class gameManager : MonoBehaviour
{
    public float InkwellHealth = 100f;
    public float Ink = 10f;

    public TMP_Text INK;
    public TMP_Text Health;

    public InfantryHealth IH;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        INK.SetText("Ink: " + Ink.ToString()+"%");
        Health.SetText("Inkwell Health: " +  InkwellHealth.ToString());
        InkwellHealth = IH.health;
    }
}
