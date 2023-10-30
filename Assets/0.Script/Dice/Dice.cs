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
    protected DataJson.DiceDetailData data;
    public float attackRange = 10f;
    Dice target;
    float fireTimer;
    float fireDelayTimer = 0.2f;
    int levelUpCnt = 0;


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
        if (diceBlock != null)
        {
            /*transform.position = target.transform.position;
            target.transform.position = startPos;*/
            //transform.position = DiceSpawn.Instance.blocks.get
            //if (target.data.name == this.data.name)
            //{
            //    Destroy(target.gameObject);
            //}

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
        if (collision.GetComponent<Dice>())
        {
            target = collision.GetComponent<Dice>();
            Debug.Log(target.transform.position);
        }
        if(collision.GetComponent<DiceBlock>())
        {
            diceBlock = collision.GetComponent<DiceBlock>();
        }
    }
     private void OnTriggerExit2D(Collider2D collision)
     {
        target = null;
        diceBlock = null;
     }

        // Start is called before the first frame update
     void Start()
     {
            //diceBlock = GetComponent<DiceBlock>();
     }

        // Update is called once per frame
     void Update()
     {
         //Attack();
     }

     public void Attack()
     {
         fireTimer += Time.deltaTime;

         if (SpawnController.Instance.spawnPos.childCount == 0)
             return;

         if (fireTimer > fireDelayTimer)
         {
             fireTimer = 0;
             Vector2 vec = fireTrans.transform.position - SpawnController.Instance.spawnPos.GetChild(0).transform.position;
             float angle = Mathf.Atan2(vec.x, vec.y) * Mathf.Rad2Deg;
             fireTrans.rotation = Quaternion.AngleAxis(angle - 270, Vector3.forward);

             DiceBullet db = Instantiate(diceBullet, fireTrans);
             //db.transform
             db.SetTarget(SpawnController.Instance.spawnPos.GetChild(0).transform);
             db.Power = data.power;
         }
     }
}
  


