using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mathematical;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject destinationPoint;
    [SerializeField] List<GameObject> poolChars;
    [SerializeField] List<GameObject> spawnParticles;
    [SerializeField] List<GameObject> destroyParticles;
    [SerializeField] GameObject hammerDestroyEffect;
    [SerializeField] List<GameObject> enemyPoolChars;
    [SerializeField] int activeCharacters = 1;
    [SerializeField] int numberOfEnemies = 1;

    bool _isBattleStart = false;
    public bool IsBattleStart { get => _isBattleStart; set { _isBattleStart = value; } }


    public GameObject DestinationPoint { get => destinationPoint; private set { destinationPoint = value; } }
    public int ActiveCharacters { get => activeCharacters ; set { activeCharacters = value; } }

    //Singleton
    public static SpawnManager spawnManager;

    private void Awake()
    {
        spawnManager = this;
    }

    private void Start()
    {
        SpawnEnemies();
    }

    void Update()
    {

    }


    public void NumericOperations(string data, Transform objectPos, int value)
    {
        switch (data)
        {
            case "Multiply":

                MathematicalOperations.Multiply(poolChars, objectPos, value);
                break;

            case "Sum":

                MathematicalOperations.Sum(poolChars, objectPos, value);
                break;

            case "Subtract":

                MathematicalOperations.Subtract(poolChars, value);
                break;

            case "Divide":

                MathematicalOperations.Divided(poolChars, value);
                break;
        }
    }


    public void DestroyEffect(GameObject item)
    {
        foreach (var effect in destroyParticles)
        {
            if (!effect.activeInHierarchy)
            {
                Vector3 effectPos = new Vector3(item.transform.position.x, 0.23f, item.transform.position.z + 1f);

                effect.SetActive(true);
                effect.transform.position = effectPos;
                effect.GetComponent<ParticleSystem>().Play();
                break;
            }
        }
    }

    public void SpawningParticles(GameObject item)
    {
        foreach (var effect in spawnParticles)
        {
            if (!effect.activeInHierarchy)
            {
                Vector3 effectPos = new Vector3(item.transform.position.x, 0.23f, item.transform.position.z + 1f);

                effect.SetActive(true);
                effect.transform.position = effectPos;
                effect.GetComponent<ParticleSystem>().Play();
                break;
            }
        }
    }

    public void HammerDestroyShow(Transform pos)
    {
        Vector3 spotPos = new Vector3(0, 0.2f, pos.position.z);

        hammerDestroyEffect.SetActive(true);
        hammerDestroyEffect.transform.position = spotPos;
        StartCoroutine(SpotDeActivate());
    }


    IEnumerator SpotDeActivate()
    {
        yield return new WaitForSeconds(2f);
        hammerDestroyEffect.SetActive(false);
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            if (!enemyPoolChars[i].activeInHierarchy)
            {
                enemyPoolChars[i].SetActive(true);
            }
        }
    }
}
