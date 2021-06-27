using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] levels;
    [SerializeField] private GameObject[] roomObjs;
    [SerializeField] private GameObject bossRoom;
    [SerializeField] private GameObject playerObj;
    private GameObject spawnPoints;
    private GameObject objs;
    private int level;
    private int rand;
    public bool needRestart;

    private float timer = 5f;
    private float delay;

    private void Start()
    {
        level = 1;
        spawnPoints = gameObject.transform.GetChild(0).gameObject;
        objs = gameObject.transform.GetChild(1).gameObject;
        spawnLevel();
        spawnObjs();
    }

    private void Update()
    {
        if(needRestart)
        {
            needRestart = false;
            restart();
        }
    }

    private void spawnLevel()
    {
        rand = Random.Range(0, levels.Length);
        GameObject level = Instantiate(levels[rand], transform.position, Quaternion.identity);
        level.transform.parent = gameObject.transform;
        GameObject bossRoomPF = Instantiate(bossRoom, transform.position, Quaternion.identity);
        bossRoomPF.transform.parent = gameObject.transform;
    }

    private void spawnObjs()
    {
        for (int i = 0; i < spawnPoints.transform.childCount; i++)
        {
            rand = Random.Range(0, roomObjs.Length);
            GameObject obj = Instantiate(roomObjs[rand], spawnPoints.transform.GetChild(i).transform.position
                , Quaternion.identity);
            obj.transform.parent = objs.transform;

        }
    }

    private void removeAllChild(GameObject obj)
    {
        foreach (Transform child in obj.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void restart()
    {
        removeAllChild(objs);
        Destroy(gameObject.transform.GetChild(2).gameObject);
        Destroy(gameObject.transform.GetChild(3).gameObject);

        spawnLevel();
        spawnObjs();

        playerObj.transform.position = Vector3.zero;

        level++;

    }
}
