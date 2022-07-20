using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destinationPoint;
    NavMeshAgent _enemyNavMesh;
    Animator _enemyAnimation;

    private void Awake()
    {
        _enemyNavMesh = GetComponent<NavMeshAgent>();
        _enemyAnimation = GetComponent<Animator>();

    }

    private void Update()
    {
        if(!SpawnManager.spawnManager.IsBattleStart){ return; }
        StartAttack();

    }

    public void StartAttack()
    {
        _enemyAnimation.SetBool("Attack", true);
        _enemyNavMesh.SetDestination(destinationPoint.transform.position);

    }
}
