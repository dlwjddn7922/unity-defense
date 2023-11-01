using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecDice : Dice
{
    public override DiceName GetName()
    {
        return DiceName.electronic;
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
        data = DataJson.Instance.diceJsonData.DiceData[1];
    }
}
