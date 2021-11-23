using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemy
{

	bool spriteDirection;

	protected override void Start()
	{
		base.Start();
		spriteDirection = spriteRenderer.flipX;
	}

	
	public override void MoveTo(Vector3 position)
	{
		if (this.moveAble)
		{
			Vector3 direction = (position - transform.position).normalized;
			Vector2 headingDirection = new Vector2(direction.x * speed, direction.y * speed);

			if (headingDirection.x >= 0)
            {
				spriteRenderer.flipX = !spriteDirection;
			}
            else
            {
				spriteRenderer.flipX = spriteDirection;
            }
			this.rb.velocity = headingDirection;
		}
	}
	

	


}
