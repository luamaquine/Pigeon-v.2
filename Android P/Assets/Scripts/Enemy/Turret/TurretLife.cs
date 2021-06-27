using UnityEngine;
using UnityEngine.UI;

public class TurretLife : LifeBehaviour
{
    [SerializeField] private int maxLife;
    [SerializeField] private Slider sliderLifeBar;
    [SerializeField] private GameObject lifeBar;

    private void Start()
    {
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
}
