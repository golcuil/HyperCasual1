using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Pool;
using static UnityEditor.PlayerSettings;

namespace Mathematical
{
    public class MathematicalOperations : MonoBehaviour
    {

        public static void Multiply(List<GameObject> poolChars, Transform objectPos, int value)
        {
            int num1 = 0;
            int loopMultiply = SpawnManager.spawnManager.ActiveCharacters * (value - 1);
            foreach (var item in poolChars)
            {
                if (num1 < loopMultiply)
                {
                    if (!item.activeInHierarchy)
                    {
                        item.transform.position = objectPos.position;
                        SpawnManager.spawnManager.SpawningParticles(item);
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
            SpawnManager.spawnManager.ActiveCharacters *= value;
        }

        public static void Sum(List<GameObject> poolChars, Transform objectPos, int value)
        {
            int num2 = 0;

            foreach (var item in poolChars)
            {
                if (num2 < value)
                {
                    if (!item.activeInHierarchy)
                    {
                        
                        item.transform.position = objectPos.position;
                        SpawnManager.spawnManager.SpawningParticles(item);
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
            SpawnManager.spawnManager.ActiveCharacters += value;
        }

        public static void Subtract(List<GameObject> poolChars, int value)
        {
            if (SpawnManager.spawnManager.ActiveCharacters <= value)
            {
                foreach (var item in poolChars)
                {
                    if (item.activeInHierarchy)
                    {
                        SpawnManager.spawnManager.DestroyEffect(item);
                        item.transform.position = Vector3.zero;
                        item.SetActive(false);
                    }

                }

                SpawnManager.spawnManager.ActiveCharacters = 1;
            }

            else
            {
                int num3 = 0;

                foreach (var item in poolChars)
                {
                    if (num3 != value)
                    {
                        if (item.activeInHierarchy)
                        {
                            SpawnManager.spawnManager.DestroyEffect(item);
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

                SpawnManager.spawnManager.ActiveCharacters -= value;
            }
        }

        public static void Divided(List<GameObject> poolChars, int value)
        {
            int divided = SpawnManager.spawnManager.ActiveCharacters / value;

                  // 5 = 22 / 4 
            if (SpawnManager.spawnManager.ActiveCharacters <= value)
            {
                foreach (var item in poolChars)
                {
                    if (item.activeInHierarchy)
                    {
                        SpawnManager.spawnManager.DestroyEffect(item);
                        item.transform.position = Vector3.zero;
                        item.SetActive(false);
                    }

                }

                SpawnManager.spawnManager.ActiveCharacters = 1;
            }
            else
            {
                int num4 = SpawnManager.spawnManager.ActiveCharacters;

                if (SpawnManager.spawnManager.ActiveCharacters % value == 0)
                {
                    SpawnManager.spawnManager.ActiveCharacters = divided;
                }
                else
                {
                    SpawnManager.spawnManager.ActiveCharacters = divided + (SpawnManager.spawnManager.ActiveCharacters % value);
                }
                

                foreach (var item in poolChars)
                {
                    if (num4 != SpawnManager.spawnManager.ActiveCharacters)
                    {
                        if (item.activeInHierarchy)
                        {
                            SpawnManager.spawnManager.DestroyEffect(item);
                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                            num4--;
                        }

                    }
                    else
                    {
                        num4 = SpawnManager.spawnManager.ActiveCharacters;
                        break;
                    }

                }

                
                
            }

        }

    }

}

