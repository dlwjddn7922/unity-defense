using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceBullet : MonoBehaviour
{
    public int Power { get; set; }
    float speed = 10f;
    private Transform target;
    Vector3 vec;
    Dice dice;
    // Start is called before the first frame update
    void Start()
    {
        dice = GetComponent<Dice>();
        //target = dice.enemytarget;
        
    }

    // Update is called once per frame
    void Update()
    {
        //dice.FindTarget();
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        transform.position += (target.position - transform.position).normalized * Time.deltaTime * speed;
        //transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
    public void SetTarget(Transform target)
    {
        this.target = target;
        //vec = target.transform.position;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Monster"))
        {
            Destroy(gameObject);
            collision.GetComponent<Monster>().Hit(Power);
        }
    }


}
