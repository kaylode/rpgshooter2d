using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected bool isAttached = false;

    protected abstract void Attack();
    public abstract void UpdatePosition(Vector2 mousePosition);

}