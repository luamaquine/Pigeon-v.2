using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage;
    private GameObject target;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            target = other.gameObject;
            target.GetComponent<PlayerLife>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if(!other.CompareTag("Enemy") && !other.CompareTag("Check") && !other.CompareTag("Bullet") && !other.CompareTag("Hole"))
        {
            Destroy(gameObject);
        }
    }
}
