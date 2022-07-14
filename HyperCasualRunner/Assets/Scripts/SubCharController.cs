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
            SpawnManager.spawnManager.DestroyEffect(gameObject);
            SpawnManager.spawnManager.ActiveCharacters--;
            this.gameObject.SetActive(false);
        }
    }
}
