using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerZone : TriggerZone
{
    public GameObject[] enemyPrefabs;
    public float radiusRange = 5f;


    protected override void Start()
    {
        triggerPoint.OnPlayerEnterTrigger += TriggerTrap;
    }

    private void TriggerTrap(object sender, System.EventArgs e)
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        foreach (GameObject obj in enemyPrefabs)
        {
            Instantiate(obj, transform.position, transform.rotation);
        }
    }
}
