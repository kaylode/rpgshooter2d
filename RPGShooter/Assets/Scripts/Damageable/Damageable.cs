using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public float health;
    protected virtual void Start() { }
    protected virtual void Update() { }
    public virtual void GetDamaged(float value) 
    {
        this.health -= value;

    }

}
