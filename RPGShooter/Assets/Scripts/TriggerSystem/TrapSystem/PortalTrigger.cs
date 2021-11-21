using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPortalTrigger : TriggerZone
{
    public GameObject portal;
    public GameObject boss;


    protected override void Start()
    {
        triggerPoint.OnPlayerEnterTrigger += SpawnBoss;
    }
    
    private void SpawnBoss(object sender, System.EventArgs e)
    {
        GameObject spawn = Instantiate(boss, transform.position, transform.rotation);
        spawn.transform.SetParent(this.transform.parent);

        spawn.gameObject.GetComponent<Boss>().OnDeathTrigger += SpawnPortal;
    }

    private void SpawnPortal(object sender, System.EventArgs e)
    {
        Instantiate(portal, transform.position, transform.rotation);
    }
}
