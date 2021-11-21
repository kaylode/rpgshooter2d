using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State
    {
        RoamingState,
        ChaseState,
        AttackState
    }

    public float RoamingRange = 4f;
    public float ChaseRange = 8f;
    public float StopChaseRange = 15f;
    public float AttackRange = 4f;

    private Enemy instance;
    private Vector2 startPosition;
    private Vector2 roamPosition;
    private float timer;
    private State currentState;


    private void Awake()
    {
        this.instance = GetComponent<Enemy>();
        this.currentState = State.RoamingState;
    }

    private void Start()
    {
        startPosition = transform.position;
        roamPosition = GetRoamingPosition();
    }

    protected virtual void Update()
    {
        Player target = GameManager.instance.player;
        this.currentState = GetCurrentState(target);
        switch (this.currentState)
        {
            case State.RoamingState:
                RoamingAround();
                break;

            case State.ChaseState:
                ChaseTarget(target);
                break;
            case State.AttackState:
                AttackTarget(target);
                break;

        }
        
    }

    private State GetCurrentState(Player player)
    {
        float distanceFromPlayer = GetDistanceFromPlayer(player);
        if (distanceFromPlayer <= this.AttackRange)
            return State.AttackState;
        else if (distanceFromPlayer <= this.ChaseRange)
            return State.ChaseState;
        else if (this.currentState == State.ChaseState && distanceFromPlayer <= this.StopChaseRange)
            return State.ChaseState;
        return State.RoamingState;
    }

    private Vector2 GetRoamingPosition()
    {
        // Generate random normalized direction
        timer = Time.time;
        Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        return startPosition + randomDirection * Random.Range(RoamingRange, RoamingRange);
    }

    private void RoamingAround()
    {
        
        this.instance.MoveTo(roamPosition);
        float reachedPositionDistance = 1f;

        if ((Vector3.Distance(transform.position, roamPosition) < reachedPositionDistance) || (Time.time - timer > 5f))
        {
            roamPosition = GetRoamingPosition();
        }
    }

    protected float GetDistanceFromPlayer(Player player)
    {
        return Vector2.Distance((Vector2)instance.transform.position, (Vector2)player.GetPosition());
    }

    protected void ChaseTarget(Player player)
    {
        this.instance.MoveTo(player.GetPosition());
    }

    protected void AttackTarget(Player player)
    {
        this.instance.AttackTo(player);
    }
}
