using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dice : Singleton<Dice>
{
    [HideInInspector] public Vector3 startPos = Vector3.zero;
    [HideInInspector] public DiceBlock diceBlock;
    [SerializeField] private Transform fireTrans;
    [SerializeField] private DiceBullet diceBullet;
    [SerializeField] private List<GameObject> MonsterList = new List<GameObject>();
    protected DataJson.DiceDetailData data;

    public float attackRange = 10f;
    private GameObject enemytarget;
    //public Transform etarget;
    Dice target;
    float fireTimer;
    float fireDelayTimer = 0.2f;


    public virtual void Init()
    {
    }
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
            Attack();
          //FindTarget()
        }
    }
    public void FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Monster");
        //float closetDis = float.MaxValue;
        //Transform closetEnemy = null;
        foreach(var enemy in enemies)
        {
            /*float dis = Vector2.Distance(transform.position, enemy.transform.position);
            if( dis <= closetDis)
            {
                closetDis = dis;
                closetEnemy = enemy.transform;
            }
            if (closetEnemy != null)
            {
                enemytarget = closetEnemy.transform;
                //enemytarget = target;
                //fireTrans.LookAt(closetEnemy.transform.position);
            }*/
            enemytarget = enemy;
        }


    }
    public void Attack()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer > fireDelayTimer)
        {
            fireTimer = 0;
            Vector2 vec = fireTrans.transform.position - enemytarget.transform.position;
            float angle = Mathf.Atan2(vec.x, vec.y) * Mathf.Rad2Deg;
            fireTrans.rotation = Quaternion.AngleAxis(angle - 270, Vector3.forward);

            DiceBullet db = Instantiate(diceBullet, fireTrans);
            //db.transform.rotation = Quaternion.identity;
            db.SetTarget(enemytarget);
            //db.transform.localPosition = Vector3.zero;
            //db.transform.localRotation = Quaternion.identity;           
        }
    }

}

