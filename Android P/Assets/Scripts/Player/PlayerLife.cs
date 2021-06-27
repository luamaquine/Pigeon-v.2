using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : LifeBehaviour
{
    [SerializeField] private int maxLife;
    [SerializeField] private Slider lifeBar;
    public GameObject gameOverCanvas;

    private void Awake()
    {
        life = maxLife;
        lifeBar.value = (float) life / maxLife;
    }
    
    public override void TakeDamage(int damageAmount)
    {
        life -= damageAmount;
        if (life <= 0)
        {
            life = 0;
            Death();
            gameOverCanvas.SetActive(true);

        }
        lifeBar.value = (float) (life-damageAmount)/maxLife;
    }

    public int GetLife()
    {
        return life;
    }

    public override void Death()
    {
        gameObject.GetComponent<PlayerMove>().enabled = false;
        gameObject.GetComponent<PlayerSkills>().enabled = false;
    }
}
