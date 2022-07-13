using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject destinationPoint;
    //[SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject prefabChar;
    [SerializeField] List<GameObject> poolChars;
    [SerializeField] int activeCharacters = 1;

    public GameObject DestinationPoint { get => destinationPoint; private set { destinationPoint = value; } }
    public int ActiveCharacters { get => activeCharacters ; set { activeCharacters = value; } }

    public static SpawnManager spawnManager;

    private void Awake()
    {
        spawnManager = this;
    }
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A))
        //{
            
        //}
    }


    public void NumericOperations(string data, Transform objectPos, int value)
    {
        switch (data)
        {
            case "Multiply":

                int num1 = 0;
                int loopMultiply = activeCharacters * (value-1);
                foreach (var item in poolChars)
                {
                    if(num1 < loopMultiply)
                    {
                        if (!item.activeInHierarchy)
                        {
                            item.transform.position = objectPos.position;
                            item.SetActive(true);
                            num1++;

                        }
                    }
                    else
                    {
                        num1 = 0;
                        break;
                    }
                   
                }
                activeCharacters *= value;
                break;

            case "Sum":

                int num2 = 0;

                foreach (var item in poolChars)
                {
                    if (num2 < value)
                    {
                        if (!item.activeInHierarchy)
                        {
                            item.transform.position = objectPos.position;
                            item.SetActive(true);
                            num2++;

                        }
                    }
                    else
                    {
                        num2 = 0;
                        break;
                    }

                }
                activeCharacters += value;
                break;

            case "Subtract":

                if(activeCharacters <= value)
                {
                    foreach(var item in poolChars)
                    {
                        if (item.activeInHierarchy)
                        {
                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                        }
                        
                    }

                    activeCharacters = 1;
                }

                else
                {
                    int num3 = 0;

                    foreach(var item in poolChars)
                    {
                        if(num3 != value)
                        {
                            if (item.activeInHierarchy)
                            {
                                item.transform.position = Vector3.zero;
                                item.SetActive(false);
                                num3++;
                            }
                            
                        }

                        else
                        {
                            num3 = 0;
                            break;
                        }
                    }

                    activeCharacters -= value;
                }

                
                break;

            case "Divide":

                int divided = activeCharacters / value;

                if (activeCharacters <= value)
                {
                    foreach (var item in poolChars)
                    {
                        if (item.activeInHierarchy)
                        {
                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                        }
                        
                    }

                    activeCharacters = 1;
                }
                else
                {
                    int num4 = 0;
                    if (activeCharacters % value == 0)
                    {
                        activeCharacters = divided;
                    }
                    else
                    {
                        activeCharacters = divided + (activeCharacters % value);
                    }

                    foreach (var item in poolChars)
                    {
                        if(num4 != activeCharacters)
                        {
                            if (item.activeInHierarchy)
                            {
                                item.transform.position = Vector3.zero;
                                item.SetActive(false);
                                num4++;
                            }
                            
                        }
                        else
                        {
                            num4 = 0;
                            break;
                        }

                    }

                    
                }

                break;
        }
    }
}
