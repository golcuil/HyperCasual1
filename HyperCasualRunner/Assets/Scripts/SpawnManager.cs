using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GeneralLibrary;

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
    MathematicalOperations _mathematicalOperations = new MathematicalOperations();
    MemoryManagement _memoryManagement = new MemoryManagement();

    public int NumberOfEnemies { get; set; }

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
        _memoryManagement.SaveData("Ad", "Ahmet");
        //_memoryManagement.SaveData("Point", 500);
        _memoryManagement.SaveData("Deneme", 1.5f);

        Debug.Log(_memoryManagement.ReadDataFloat("Deneme"));
        Debug.Log(_memoryManagement.ReadDataInt("Point"));
        Debug.Log(_memoryManagement.ReadDataStr("Ad"));
        SpawnEnemies();
    }


    public void NumericOperations(string data, Transform objectPos, int value)
    {
        switch (data)
        {
            case "Multiply":

                _mathematicalOperations.Multiply(poolChars, objectPos, value);
                break;

            case "Sum":

                _mathematicalOperations.Sum(poolChars, objectPos, value);
                break;

            case "Subtract":

                _mathematicalOperations.Subtract(poolChars, value);
                break;

            case "Divide":

                _mathematicalOperations.Divided(poolChars, value);
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
                effect.GetComponent<AudioSource>().Play();
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


    public IEnumerator EndOfGame()
    {
        int result = activeCharacters - numberOfEnemies;
        string a = "tie";

        if(result <= 0)
        {
            a = "Lost";
        }
        else
        {
            a = "Win";
        }

        yield return new WaitForSeconds(2.5f);

        _memoryManagement.SaveData("Point", 500 + _memoryManagement.ReadDataInt("Point"));
        EndAnimations();
        Debug.Log(a);

    }

    void EndAnimations()
    {
        SpawnManager.spawnManager.IsBattleStart = false;

        foreach (var enemy in enemyPoolChars)
        {
            if (enemy.activeInHierarchy)
            {
                enemy.GetComponent<Animator>().SetBool("Attack", false);
            }           
        }

        foreach (var subChar in poolChars)
        {
            if (subChar.activeInHierarchy)
            {
                subChar.GetComponent<Animator>().SetBool("Attack", false);
            }
        }

    }
}
