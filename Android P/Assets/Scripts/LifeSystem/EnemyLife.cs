using UnityEngine;
using UnityEngine.UI;

public class EnemyLife : LifeBehaviour
{
    [SerializeField] private int maxLife;
    private Slider sliderLifeBar;
    private GameObject lifeBar;

    private void Start()
    {
        lifeBar = gameObject.transform.GetChild(1).gameObject;
        sliderLifeBar = lifeBar.transform.GetChild(0).GetComponent<Slider>();
        life = maxLife;
        sliderLifeBar.value = (float) life / maxLife;
        lifeBar.SetActive(false);
    }
    
    public override void TakeDamage(int damageAmount)
    {
        base.TakeDamage(damageAmount);
        lifeBar.SetActive(true);
        sliderLifeBar.value = (float) (life-damageAmount)/maxLife;
    }
    
    public int GetLife()
    {
        return life;
    }
    public void IsDead()
    {
        life = 0;
        TakeDamage(10);
        FindObjectOfType<AudioManager>().Play("EnemyDie");
    }
}
