using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWall : MonoBehaviour
{
    private GameObject target;
    public bool isWall;
    public int damage;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(!other.CompareTag("Bullet") && !other.CompareTag("Check"))
        {
            isWall = true;
        }
            
        if (other.CompareTag("Player"))
        {
            isWall = true;
            target = other.gameObject;
            target.GetComponent<PlayerLife>().TakeDamage(damage);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isWall = false;
    }
}
