using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    /*
     * Zone affected by a trigger point
     */

    public TriggerPoint triggerPoint;

    protected virtual void Start()
    {
        triggerPoint.OnPlayerEnterTrigger += TriggerFunction;
    }

    protected virtual void TriggerFunction(object sender, System.EventArgs e) { }

}
