using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecDice : Dice
{
    // Start is called before the first frame update
    void Start()
    {
        //Init(1);
        data = DataJson.Instance.diceJsonData.DiceData[1];
    }
}
