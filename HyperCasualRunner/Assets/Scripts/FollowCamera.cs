using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform battlefieldCameraPos;
    Vector3 _offSet;

    // Start is called before the first frame update
    void Start()
    {
        _offSet = transform.position - player.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!SpawnManager.spawnManager.IsBattleStart)
        {
            transform.position = Vector3.Lerp(transform.position, player.position + _offSet, 0.125f);
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, battlefieldCameraPos.position, 0.08f);
        }
        
    }
}
