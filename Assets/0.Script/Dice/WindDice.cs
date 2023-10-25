using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindDice : Dice
{
    // Start is called before the first frame update
    void Start()
    {
        //Init(2);
        data = DataJson.Instance.diceJsonData.DiceData[2];
    }
}
