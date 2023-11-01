using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindDice : Dice
{
    public override DiceName GetName()
    {
        return DiceName.wind;
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
        data = DataJson.Instance.diceJsonData.DiceData[2];
    }
}
