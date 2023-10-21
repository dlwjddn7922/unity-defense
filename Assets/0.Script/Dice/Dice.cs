using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dice : MonoBehaviour
{
    [HideInInspector] public Vector3 startPos = Vector3.zero;
    [HideInInspector] public DiceBlock diceBlock;
    [SerializeField] private Transform fireTrans;
    [SerializeField] private DiceBullet diceBullet;
    [SerializeField] private List<GameObject> MonsterList = new List<GameObject>();

    public LayerMask layerMask;
    public Transform etarget;
    Dice target;
    float fireTimer;
    float fireDelayTimer = 1f;


    public void OnMouseDown()
    {
        startPos = transform.position;
        target = null;
    }
    public void OnMouseUp()
    {
        if (target)
        {
            transform.position = target.transform.position;
            target.transform.position = startPos;

        }
        else
        {
            transform.position = startPos;

        }
        target = null;

    }
    void OnMouseDrag()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.Translate(mousePos);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        target = collision.GetComponent<Dice>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        target = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        diceBlock = GetComponent<DiceBlock>();
    }

    // Update is called once per frame
    void Update()
    {
        FindTarget(etarget);
    }
    Monster FindEnemy()
    {
        Monster[] enemies = FindObjectsOfType<Monster>();

        float minDis = float.MaxValue;
        Monster m = null;
        foreach (var enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (minDis >= distance)
            {
                minDis = distance;
                m = enemy;
            }
        }
        return m;
    }
    public void Attack()
    {
        Monster enemy = FindEnemy();
        if (enemy == null)
        {
            return;
        }

        Vector3 vec = new Vector3(enemy.transform.position.x, enemy.transform.position.y);

        fireTimer += Time.deltaTime;
        if (fireTimer > fireDelayTimer)
        {
            fireTimer = 0f;

            DiceBullet b = Instantiate(diceBullet, fireTrans);
            b.SetTarget(enemy.transform);
            Debug.Log(enemy.name);
            b.transform.SetParent(null);
            b.transform.Translate(vec);
        }
    }
    public void FindTarget(List<Monster> MonsterList)
    {
        for (int i = 0; i < MonsterList.Count; i++)
        {
            RaycastHit hit;
            bool isHit = Physics.Raycast(transform.position, MonsterList[i].transform.position - transform.position, out hit, 20f, layerMask);
            float distance = float.MaxValue;
            if (isHit && hit.transform.CompareTag("Monster"))
            {
                float dis = Vector2.Distance(transform.position, MonsterList[i].transform.position);
                if (dis < distance)
                {
                    distance = dis;
                    etarget = MonsterList[i].transform;
                    Debug.Log(etarget.name);
                }
            }
        }
    }
/*    void Attack()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer > fireDelayTimer)
        {
            fireTimer = 0;
            DiceBullet db = Instantiate(diceBullet, fireTrans);
            //db.transform.Translate(MonsterList[0].transform.position);
        }
    }*/
}

