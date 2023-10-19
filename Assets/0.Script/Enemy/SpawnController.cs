using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SpawnController : MonoBehaviour
{
    float timer;
    float spawnTimer = 2f;
    int maxSpawnCnt = 20;
    int spawnCnt;
    [SerializeField] private Monster monster;
    [SerializeField] private Transform spawnPos;
    [SerializeField] Transform[] wayPoints;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > spawnTimer && spawnCnt < maxSpawnCnt)
        {
            Monster mon = Instantiate(monster);
            mon.MonRoad(wayPoints);
            mon.transform.SetParent(spawnPos);

            timer = 0;
            spawnCnt++;
        }
    }
}
