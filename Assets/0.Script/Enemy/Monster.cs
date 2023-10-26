using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class Monster : MonoBehaviour
{
    SpriteRenderer sr;
    [SerializeField] TMP_Text hpTxt;
    protected DataJson.MonsterDetailData data;
    private float hp;
    protected float HP
    { 
        get
        {
            return hp;
        }
        set
        {
            hp = value; 
            hpTxt.text =  $"{ hp}";
        }
            }
    protected float Speed { get; set; }

    // Start is called before the first frame update
    public virtual void Init()
    {
        HP = data.hp;
        Speed = data.speed;
    }
    void Start()
    {
        //DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
    }

    // Update is called once per frame
    void Update()
    {
        //hpTxt = HP;
    }
    public void MonRoad(Transform[] road)
    {
        sr = GetComponent<SpriteRenderer>();

        Vector3[] wayPointsVec = new Vector3[road.Length];
        for (int i = 0; i < road.Length; i++)
        {
            wayPointsVec.SetValue(road[i].position, i);
        }

        transform.DOPath(wayPointsVec, 10f)
            .SetEase(Ease.Linear)
            .OnComplete(() => Destroy(gameObject));
        sr.DOFade(1f, 0.3f);
    }
    public void Hit(float damage)
    {
        HP -= damage;
        if(HP <= 0)
        {
            transform.DOKill();
            Destroy(gameObject);
        }
    }
}
