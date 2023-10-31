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
            if(diceBlock.dice == null)
            {
                transform.position = diceBlock.transform.position;
            }
        }
        else
        {
            transform.position = startPos;
        }
        diceBlock = null;
    }
    void OnMouseDrag()
     {
         Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
         transform.Translate(mousePos);
     }
     private void OnTriggerEnter2D(Collider2D collision)
     {
        /*        if (collision.GetComponent<Dice>())
                {
                    target = collision.gameObject.GetComponent<Dice>();
                    Destroy(target.gameObject);
                    //Debug.Log(this.data.name);
                    //Debug.Log(target.data.name);
                }*/
        if (collision.GetComponent<DiceBlock>())
        {
            diceBlock = collision.GetComponent<DiceBlock>();

        }
    }
     private void OnTriggerExit2D(Collider2D collision)
     {
        //target = null;
        diceBlock = null;
     }

        // Start is called before the first frame update
     void Start()
     {
        //target = GetComponent<Dice>();
        diceBlock = GetComponent<DiceBlock>();
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
  


