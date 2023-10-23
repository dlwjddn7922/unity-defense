using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceBullet : MonoBehaviour
{
    float speed = 3f;
    [SerializeField ]Transform target;
    Vector3 vec;
    Dice dice;
    // Start is called before the first frame update
    void Start()
    {
        dice = GetComponent<Dice>();
    }

    // Update is called once per frame
    void Update()
    {
        //dice.Attack()
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
    public void SetTarget(Transform target)
    {
        this.target = target;
        Vector3 vec = new Vector3(target.transform.position.x, target.transform.position.y) * speed;
    }
}
