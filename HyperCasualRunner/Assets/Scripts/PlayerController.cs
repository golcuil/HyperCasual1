using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    [SerializeField] float slideSpeed = 0.75f;
    [SerializeField] float lerpSpeed = 0.3f;
    [SerializeField] SpawnManager spawnManager;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(Input.GetAxis("Mouse X") < 0)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3((transform.position.x - slideSpeed),
                                            transform.position.y, transform.position.z), lerpSpeed);
            }
            if(Input.GetAxis("Mouse X") > 0)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3((transform.position.x + slideSpeed),
                                            transform.position.y, transform.position.z),lerpSpeed);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Multiply") || other.CompareTag("Sum") || other.CompareTag("Subtract") || other.CompareTag("Divide"))
        {
            int value = int.Parse(other.gameObject.name);
            spawnManager.NumericOperations(other.tag,other.gameObject.transform,value);
        }
    }
}
