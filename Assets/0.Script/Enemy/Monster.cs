using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Monster : MonoBehaviour
{
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init(false, true, LogBehaviour.ErrorsOnly);

    }

    // Update is called once per frame
    void Update()
    {
        
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
}
