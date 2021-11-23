using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vendor : NPC
{
    private delegate void UpgradeMenuCallback(bool active);
    public UpgradeMenu upgradeMenu;

    protected override void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (this.interacble)
            {
                Shopping();
            }
        }
    }

    protected void Shopping()
    {
        Debug.Log(upgradeMenu.gameObject.activeSelf);
        Debug.Log(upgradeMenu.transform.gameObject.activeSelf);
        upgradeMenu.Toggle();
        
    }
}
