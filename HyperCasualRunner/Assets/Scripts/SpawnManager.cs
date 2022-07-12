using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject destinationPoint;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject prefabChar;

    public GameObject SpawnPoint { get; private set; }
    public GameObject DestinationPoint { get => destinationPoint; private set { spawnPoint = value; } }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(prefabChar, spawnPoint.transform.position, Quaternion.identity);
        }
    }
}
