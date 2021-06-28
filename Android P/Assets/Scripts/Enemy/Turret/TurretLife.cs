using UnityEngine;
using UnityEngine.UI;

public class TurretLife : LifeBehaviour
{
    [SerializeField] private int maxLife;
    [SerializeField] private Slider sliderLifeBar;
    [SerializeField] private GameObject lifeBar;
    private Animator anim;
    private bool haveAnim; 

    private void Start()
    {
        if (gameObject.transform.GetChild(0).GetComponent<Animator>() != null)
        {
            haveAnim = true;
            anim = gameObject.transform.GetChild(0).GetComponent<Animator>();
        }
        
        life = maxLife;
        sliderLifeBar.value = (float) life / maxLife;
        lifeBar.SetActive(false);
    }
    
    public override void TakeDamage(int damageAmount)
    {
        base.TakeDamage(damageAmount);
        //if(haveAnim) anim.SetTrigger(Shoot1);
        lifeBar.SetActive(true);
        sliderLifeBar.value = (float) (life-damageAmount)/maxLife;
    }
}
