using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Collectible
{

    protected bool isAttached = false;
    public float durability = 0;
    public float useCost = 0;

    protected abstract void Attack();
    public abstract void UpdatePosition(Vector2 mousePosition);
    protected abstract void UpdateDurability(float value);

    protected override void Update()
    {

        if (this.isAttached)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.UpdatePosition(mousePosition);
        }

        if (Input.GetButton("Fire1"))
        {
            if (this.isAttached)
            {
                this.Attack();
                this.UpdateDurability(this.useCost);
            }
        }
    }

    public void Attach(Player player)
    {
        this.transform.parent = player.transform;
        this.isAttached = true;
        this.transform.localRotation = Quaternion.identity;
        this.transform.localPosition = new Vector3(0.25f, 0.5f, 0f);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Player player = collision.GetComponent<Player>();
            this.Attach(player);
            player.EquipWeapon(this);
            SoundManager.instance.PlaySound("Pickup");
            player.AddItemToInventory(this);
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), this.GetComponent<Collider2D>(), true);
        }
    }
}