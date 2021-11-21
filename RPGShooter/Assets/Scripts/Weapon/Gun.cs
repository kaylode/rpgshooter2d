using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shootable))]
public class Gun : Weapon
{
    public Shootable shooter;

    protected override void UpdateDurability(float value)
    {
        this.durability += value;
    }

    private void UpdateFirePointWithMousePosition(Vector2 mousePosition)
    {
        Vector2 firePointPos = shooter.firePoint.position;
        Vector2 lookDirection = mousePosition - firePointPos;

        float magnitue = lookDirection.magnitude;

        if (magnitue >= 1.5)
        {
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            var rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            this.transform.rotation = rotation;
        }


        if (lookDirection.x > 0)
        {
            this.transform.eulerAngles = new Vector3(
                this.transform.eulerAngles.x,
                this.transform.eulerAngles.y,
                this.transform.eulerAngles.z
            );
        }
        else
        {
            this.transform.eulerAngles = new Vector3(
                this.transform.eulerAngles.x - 180,
                this.transform.eulerAngles.y,
                - this.transform.eulerAngles.z
            );
        }

    }

    public override void UpdatePosition(Vector2 mousePosition)
    {
        this.UpdateFirePointWithMousePosition(mousePosition);
    }

    protected override void Attack()
    {
        this.shooter.ShootBullet();
    }
}