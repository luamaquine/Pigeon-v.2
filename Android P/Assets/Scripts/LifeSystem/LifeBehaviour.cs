using UnityEngine;

public abstract class LifeBehaviour : MonoBehaviour
{
    protected int life;

    public virtual void TakeDamage(int damageAmount)
    {
        life -= damageAmount;
        if (life <= 0)
        {
            life = 0;
            Death();
        }
    }

    public virtual void Death()
    {
        Destroy(gameObject);
    }
}
