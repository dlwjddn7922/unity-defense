using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    float scanRange = MaxValue.float;
    public LayerMask targetLayer;
    public RaycastHit2D[] targets;
    public Transform nearestTarget;
    // Update is called once per frame
    void Update()
    {
        target = Physics2D.circleCastAll(transform.position,scanRange, Vector2.zero,0,targetLayer);
        nearestTarget = GetNearest();
        //Debug.Log(nearestTarget.name);
    }

    Transform GetNearest()
    {
        Transform result = null
        float diff = 100;

        foreach (RaycastHit2D target in targets) 
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;
            float curDiff = Vector3.Distance(myPos, targetPos);

            if(curDiff < diff)
            {
                diff = curDiff;
                result = target.transform;
            }
        }
        return result;
    }
}
