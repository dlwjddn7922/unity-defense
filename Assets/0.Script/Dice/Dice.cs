using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dice : MonoBehaviour
{
    [HideInInspector] public Vector3 startPos = Vector3.zero;
    [HideInInspector] public DiceBlock diceBlock;
    [SerializeField] private Transform fireTrans;
    [SerializeField] private DiceBullet diceBullet;

    Monster mon;
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
        if(target)
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
        mon = GetComponent<Monster>();
        diceBlock = GetComponent<DiceBlock>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FindCloseTarget()
    {

    }
}
