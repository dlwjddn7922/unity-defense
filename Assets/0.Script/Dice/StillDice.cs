using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StillDice : Dice
{
    // Start is called before the first frame update
    void Start()
    {
        data = DataJson.Instance.diceJsonData.DiceData[4];
    }

}
