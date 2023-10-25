using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster0 : Monster
{
    // Start is called before the first frame update
    void Start()
    {
        data = DataJson.Instance.monsterJsonData.MonsterData[0];
    }

}
