using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    public int damage;
    private GameObject target;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            target = other.gameObject;
            target.GetComponent<EnemyLife>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if(!other.CompareTag("Player") && !other.CompareTag("Check") && !other.CompareTag("Bullet") && !other.CompareTag("Hole"))
        {
            Destroy(gameObject);
        }
    }
    
}
