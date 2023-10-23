using System;
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

    public float attackRange = 10f;
    private Transform enemytarget;
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
        //Attack();
        FindTarget();
        if(enemytarget != null)
        {
            float disToTarget =Vector3.Distance(transform.position, enemytarget.position);
            if(disToTarget <= attackRange)
            {
                Attack();
            }
        }
    }
/*    Monster FindEnemy()
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
    }*/
/*    public void Attack()
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
        }
    }*/
    public void FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Monster");
        float closetDis = float.MaxValue;
        GameObject closetEnemy = null;
        foreach(var enemy in enemies)
        {
            float dis = Vector3.Distance(transform.position, enemy.transform.position);
            if( dis <= closetDis)
            {
                closetDis = dis;
                closetEnemy = enemy;
            }
        }
        if(closetEnemy != null)
        {
            enemytarget = closetEnemy.transform;
            //fireTrans.LookAt(closetEnemy.transform.position);
            
            Debug.Log(enemytarget.name);
        }
    }
    public void Attack()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer > fireDelayTimer)
        {
            fireTimer = 0;

            Vector2 vec = fireTrans.position - enemytarget.transform.position;
            float angle = Mathf.Atan2(vec.x, vec.y) * Mathf.Rad2Deg;
            fireTrans.rotation = Quaternion.AngleAxis(angle + 30, Vector3.forward);
            

            DiceBullet db = Instantiate(diceBullet, fireTrans);
            //db.transform.rotation = Quaternion.identity;
            //db.SetTarget(enemytarget);
            db.transform.localPosition = Vector3.zero;
            db.transform.localRotation = Quaternion.identity;           
        }
    }
}

