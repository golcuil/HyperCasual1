using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SubCharController : MonoBehaviour
{
    SpawnManager _spawnManager;
    Transform _target;
    NavMeshAgent navMesh;


    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        _spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
        _target = _spawnManager.DestinationPoint.transform;
    }

    // Update is called once per frame
    void Update()
    {
        navMesh.SetDestination(_target.position);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("niddle"))
        {
            DestroyingSequence(gameObject);
        }

        if (other.CompareTag("SawNiddle"))
        {
            DestroyingSequence(gameObject);
        }

        if (other.CompareTag("WindNiddle"))
        {
            DestroyingSequence(gameObject);
        }

        if (other.CompareTag("Hammer"))
        {
            DestroyingSequence(gameObject);
            SpawnManager.spawnManager.HammerDestroyShow(other.gameObject.transform);
        }

        if (other.CompareTag("Enemy"))
        {
            DestroyingSequence(gameObject);
            other.gameObject.SetActive(false);
            SpawnManager.spawnManager.NumberOfEnemies--;
        }
    }

    public void DestroyingSequence(GameObject gameObject)
    {
        SpawnManager.spawnManager.DestroyEffect(gameObject);
        SpawnManager.spawnManager.ActiveCharacters--;
        gameObject.SetActive(false);
    }
}
