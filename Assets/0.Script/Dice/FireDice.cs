using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDice : Dice
{
    public override DiceName GetName()
    {
        return DiceName.fire;
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
        data = DataJson.Instance.diceJsonData.DiceData[0];
    }

}
