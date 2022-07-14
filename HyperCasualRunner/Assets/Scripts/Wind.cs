using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float delay = 3f;
    [SerializeField] BoxCollider windAreaCollider;


    public void WindAnimationStarter(string value)
    {
        if(value == "true")
        {
            animator.SetBool("Wind", true);
            windAreaCollider.enabled = true;

        }
        else
        {
            animator.SetBool("Wind", false);
            windAreaCollider.enabled = false;
            StartCoroutine(WindTimer());
        }

    }

    IEnumerator WindTimer()
    {
        yield return new WaitForSeconds(delay);
        WindAnimationStarter("true");
    }

   
}
