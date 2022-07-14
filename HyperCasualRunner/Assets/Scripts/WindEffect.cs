using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindEffect : MonoBehaviour
{
    [SerializeField] int forceValue = 10;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("SubChars"))
        {
            other.GetComponent<Rigidbody>().AddForce(Vector3.left * forceValue, ForceMode.Impulse);
        }
    }
}
