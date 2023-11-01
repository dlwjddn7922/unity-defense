using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosionDice : Dice
{
    public override DiceName GetName()
    {
        return DiceName.poision;
    }

    // Start is called before the first frame update
    void Start()
    {
        data = DataJson.Instance.diceJsonData.DiceData[3];
        Init();
    }

}
