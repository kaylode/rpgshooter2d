using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    GameObject firePoint;
    private SpriteRenderer spriteRenderer;

    private float angle;
    // Start is called before the first frame update
    void Start()
    {
        firePoint = GameObject.Find("FirePoint");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void UpdateFirePointWithMousePosition(Vector2 mousePosition)
    {
        Vector2 firePointPos = firePoint.transform.position;
        Vector2 lookDirection = mousePosition - firePointPos;

        float magnitue = lookDirection.magnitude;


        if (lookDirection.x >= 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, -1f, 1f);
        }

        if (magnitue >= 1.5)
        {
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            var rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = rotation;
        }

    }

    public void UpdatePosition(Vector2 mousePosition)
    {
        UpdateFirePointWithMousePosition(mousePosition);
    }
}
