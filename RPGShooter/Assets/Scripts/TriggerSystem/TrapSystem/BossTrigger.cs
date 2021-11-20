using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTriggerZone : EnemyTriggerZone
{

    private void SpawnEnemies()
    {
        foreach (GameObject obj in enemyPrefabs)
        {
            Vector3 position = GetRandomPosition();
            Instantiate(obj, transform.position + position, transform.rotation);
        }
    }

    private Vector3 GetRandomPosition()
    {
        return Random.insideUnitCircle * this.radiusRange;
    }
}
