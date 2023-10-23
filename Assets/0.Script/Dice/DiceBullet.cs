using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceBullet : MonoBehaviour
{
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
        //transform.position = Vector3.MoveTowards(transform.position, target.transform.position * Time.deltaTime * speed, 0.1f);
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
    public void SetTarget(Transform target)
    {
        this.target = target;
        vec = target.transform.position;
    }


}
