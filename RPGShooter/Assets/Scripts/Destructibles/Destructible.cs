using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : Damageable
{
    protected virtual void OnDestroyed() { }
    protected virtual void Destroy() { }

}
