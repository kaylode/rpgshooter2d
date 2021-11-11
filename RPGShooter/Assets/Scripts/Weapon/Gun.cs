using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : Weapon
{
    public Shootable shooter;
    // Start is called before the first frame update
    void Start(){}

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            this.Attack();
        }
    }

    private void UpdateFirePointWithMousePosition(Vector2 mousePosition)
    {
        Vector2 firePointPos = shooter.firePoint.position;
        Vector2 lookDirection = mousePosition - firePointPos;

        float magnitue = lookDirection.magnitude;

        if (lookDirection.x >= 0)
        {
            this.transform.localRotation = Quaternion.Euler(1, 1, 1);
        }
        else
        {
            this.transform.localRotation = Quaternion.Euler(1, -1, 1);
        }
        print(this.transform.localRotation);

        if (magnitue >= 1.5)
        {
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            var rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            this.transform.rotation = rotation;
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