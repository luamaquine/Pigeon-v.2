using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttack : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private Animator anim;
    private Transform barrelPos;
    private GameObject playerObj;
    private Vector3 dir;
    private bool haveAnim;

    [SerializeField] private int damage;
    [SerializeField] private float velBullet;
    [SerializeField] private float shootCD;
    private float timeLastShoot;
    private static readonly int Shoot1 = Animator.StringToHash("Shoot");

    private void Start()
    {
        if (gameObject.transform.GetChild(0).GetComponent<Animator>() != null)
        {
            haveAnim = true;
            anim = gameObject.transform.GetChild(0).GetComponent<Animator>();
        }
        barrelPos = gameObject.transform.GetChild(1).transform;
        playerObj = GameObject.FindWithTag("Player").gameObject.transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        UpdateRotation();
        if (timeLastShoot < shootCD) timeLastShoot += Time.deltaTime;
        if(timeLastShoot >= shootCD) Shoot();
    }

    public void Shoot()
    {
        if(haveAnim) anim.SetTrigger(Shoot1);
        dir = (playerObj.transform.position - transform.position).normalized;
        float angulo = AnguloEntreDoisPontos(playerObj.transform.position,transform.position);
        GameObject newBullet = Instantiate(bullet,barrelPos.position,Quaternion.Euler(new Vector3(0f,0f,angulo)));
        newBullet.GetComponent<Rigidbody2D>().velocity = dir*velBullet;
        newBullet.GetComponent<EnemyBullet>().damage = damage;
        timeLastShoot = 0;
    }

    public void UpdateRotation()
    {
        float angulo = AnguloEntreDoisPontos(playerObj.transform.position,transform.position);
        transform.rotation = Quaternion.Euler(new Vector3(0f,0f,angulo));
    }
    
    private float AnguloEntreDoisPontos(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
