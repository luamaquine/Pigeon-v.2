using System;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rig;
    private PlayerLife lifeController;
    
    private static readonly int HorizontalMove = Animator.StringToHash("HorizontalMove");
    private static readonly int Walking = Animator.StringToHash("Walking");
    private static readonly int VerticalMove = Animator.StringToHash("VerticalMove");
    private static readonly int Death = Animator.StringToHash("Death");

    private void Start()
    {
        anim = GetComponent<Animator>();
        rig = gameObject.transform.parent.GetComponent<Rigidbody2D>();
        lifeController = gameObject.transform.parent.GetComponent<PlayerLife>();
    }

    private void Update()
    {
        anim.SetBool(HorizontalMove,false);
        anim.SetBool(Walking,false);
        anim.SetFloat(VerticalMove,rig.velocity.y);
        
        if (rig.velocity.x > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool(Walking,true);
            if (rig.velocity.x > 1f)
                anim.SetBool(HorizontalMove,true);
        }
        else if (rig.velocity.x < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool(Walking,true);
            if (rig.velocity.x < -1f)
                anim.SetBool(HorizontalMove,true);
        }

        if (rig.velocity.y != 0)
        {
            anim.SetBool(Walking,true);
        }

        if (lifeController.GetLife() <= 0)
        {
            rig.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger(Death);
            
        }

    }
}
