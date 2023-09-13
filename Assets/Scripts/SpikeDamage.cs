using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    [SerializeField] private int damage = 50;

    bool canDamage = true;

    private void OnCollisionStay2D(Collision2D other) {
        if (canDamage && other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DamagePlayerCoroutine(other.gameObject.GetComponent<PlayerHealth>()));
        }
    }

    private IEnumerator DamagePlayerCoroutine(PlayerHealth playerHealth)
    {
        canDamage = false; 


        playerHealth.TakeDamage(damage);


        yield return new WaitForSeconds(0.5f);

        canDamage = true;
    }
    

}
