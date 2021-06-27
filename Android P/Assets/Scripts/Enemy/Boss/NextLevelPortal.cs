using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

public class NextLevelPortal : MonoBehaviour
{
    [SerializeField] private EnemyLife bossLife;
    private LevelSpawn levelSp;
    private GameObject portal;
    private bool isDead;
    public GameObject nextLevelCanvas;
    
    public bool pigeonsIsPower;
    
    private void Start()
    {
        levelSp = GameObject.FindWithTag("GameController").gameObject.GetComponent<LevelSpawn>();
        portal = gameObject.transform.GetChild(0).gameObject;
        portal.SetActive(false);
    }

    private void Update()
    {
        if (bossLife == null) isDead = true;
        if (isDead)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            nextLevelCanvas.SetActive(true);
            portal.SetActive(true);
        }
        if (pigeonsIsPower)
        {
            bossLife.IsDead();
            pigeonsIsPower = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            levelSp.needRestart = true;
    }

    public void Destroy()
    {
        Destroy(nextLevelCanvas);
    }
}
