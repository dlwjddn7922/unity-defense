using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDice : Dice
{
    // Start is called before the first frame update
    void Start()
    {
        //Init(0);
        data = DataJson.Instance.diceJsonData.DiceData[0];
    }

}
