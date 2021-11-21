using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigger : TriggerZone
{
    public Portal portal;
    public Boss boss;

    protected override void Start()
    {
        // triggerPoint.OnPlayerEnterTrigger += SpawnPortal;
        boss.OnDeathTrigger += SpawnPortal;
    }

    private void SpawnPortal(object sender, System.EventArgs e)
    {
        Instantiate(portal, transform.position, transform.rotation);
    }
}
