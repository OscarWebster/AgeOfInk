using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeButton : MonoBehaviour
{
    public DrawGlyph DG;

    public void upgradeTroop()
    {
        DG.isUpgraded = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            upgradeTroop();
        }
    }

    
}
