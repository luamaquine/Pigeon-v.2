using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Minigun : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private Animator anim;
    private Transform barrelPos;
    private Vector3 dir;

    private GameObject aimObj;
    
    [SerializeField] private int damage;
    [SerializeField] private float velBullet;
    [SerializeField] private float shootCD;
    private float timeLastShoot;

    private void Start()
    {
        barrelPos = gameObject.transform.GetChild(0).transform;
        aimObj = gameObject.transform.GetChild(1).gameObject;
    }

    private void Update()
    {
        if (timeLastShoot < shootCD) timeLastShoot += Time.deltaTime;
        if(timeLastShoot >= shootCD) Shoot();
    }

    public void Shoot()
    {
        dir = (aimObj.transform.position - transform.position).normalized;
        GameObject newBullet = Instantiate(bullet,barrelPos.position,Quaternion.Euler(new Vector2(0f,0f)));
        newBullet.GetComponent<Rigidbody2D>().velocity = dir*velBullet;
        newBullet.GetComponent<EnemyBullet>().damage = damage;
        timeLastShoot = 0;
    }
    
}
