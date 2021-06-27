using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoombarMove : MonoBehaviour
{
    private CheckWall verticalCheck;
    private CheckWall horizontalCheck;
    private Rigidbody2D rig;
    [SerializeField] private float speed;
    [SerializeField] private int damageColision;
    
    private int rand1;
    private int rand2;
    private Vector2 dir;

    private void Start()
    {
        rand1 = Random.Range(0,11);
        rand2 = Random.Range(0,11);
        dir = new Vector2(rand1, rand2).normalized;

        horizontalCheck = gameObject.transform.GetChild(2).gameObject.GetComponent<CheckWall>();
        horizontalCheck.damage = damageColision;
        verticalCheck = gameObject.transform.GetChild(3).gameObject.GetComponent<CheckWall>();
        verticalCheck.damage = damageColision;

        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (horizontalCheck.isWall) dir.x*=-1;
        if (verticalCheck.isWall) dir.y*=-1;
        rig.velocity = dir * speed;
    }
}
