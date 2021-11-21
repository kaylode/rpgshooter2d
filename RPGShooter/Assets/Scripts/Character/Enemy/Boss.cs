using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public event EventHandler OnDeathTrigger;

	// Trigger the trigger zone
	protected void InvokeTrigger()
	{
		EventHandler handler = OnDeathTrigger;
		if (handler != null)
			handler(this, EventArgs.Empty);

	}


	protected override void Die()
	{
		if (reward)
		{
			float rand = UnityEngine.Random.Range(0f, 1f);
			if (rand <= this.dropRate)
			{
				GameObject obj = Instantiate(reward, transform.position, transform.rotation);
				obj.transform.position = transform.position;
			}	
		}
		InvokeTrigger();
		Destroy(gameObject);
	}
}
