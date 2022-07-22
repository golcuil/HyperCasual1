using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Pool;
//using static UnityEditor.PlayerSettings;

namespace GeneralLibrary
{
    public class MathematicalOperations 
    {

        public void Multiply(List<GameObject> poolChars, Transform objectPos, int value)
        {
            int num1 = 0;
            int loopMultiply = SpawnManager.spawnManager.ActiveCharacters * (value - 1);
            foreach (var item in poolChars)
            {
                if (num1 < loopMultiply)
                {
                    if (!item.activeInHierarchy)
                    {
                        item.transform.position = new Vector3(objectPos.position.x,objectPos.position.y,objectPos.position.z - 1f);
                        SpawnManager.spawnManager.SpawningParticles(item);
                        item.SetActive(true);
                        item.GetComponent<AudioSource>().Play();
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

        public void Sum(List<GameObject> poolChars, Transform objectPos, int value)
        {
            int num2 = 0;

            foreach (var item in poolChars)
            {
                if (num2 < value)
                {
                    if (!item.activeInHierarchy)
                    {
                        
                        item.transform.position = new Vector3(objectPos.position.x, objectPos.position.y, objectPos.position.z - 1f); ;
                        SpawnManager.spawnManager.SpawningParticles(item);
                        item.SetActive(true);
                        item.GetComponent<AudioSource>().Play();
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

        public void Subtract(List<GameObject> poolChars, int value)
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

        public void Divided(List<GameObject> poolChars, int value)
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

    public class MemoryManagement
    {
        public void SaveData(string Key, string Value)
        {
            PlayerPrefs.SetString(Key, Value);
            PlayerPrefs.Save();
        }

        public void SaveData(string Key, int Value)
        {
            PlayerPrefs.SetInt(Key, Value);
            PlayerPrefs.Save();
        }

        public void SaveData(string Key, float Value)
        {
            PlayerPrefs.SetFloat(Key, Value);
            PlayerPrefs.Save();
        }


        public string ReadDataStr(string Key)
        {
            return PlayerPrefs.GetString(Key);
        }

        public int ReadDataInt(string Key)
        {
            return PlayerPrefs.GetInt(Key);
        }

        public float ReadDataFloat(string Key)
        {
            return PlayerPrefs.GetFloat(Key);
        }

    }

}

