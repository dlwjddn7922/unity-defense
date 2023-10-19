using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Monster : MonoBehaviour
{
    [SerializeField] Transform[] wayPoints;
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init(false, true, LogBehaviour.ErrorsOnly);

        Vector3[] wayPointsVec = new Vector3[wayPoints.Length];
        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPointsVec.SetValue(wayPoints[i].position, i);
        }

        transform.DOPath(wayPointsVec, 10f)
            .SetEase(Ease.Linear)
            .OnComplete(() => Destroy(gameObject));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
