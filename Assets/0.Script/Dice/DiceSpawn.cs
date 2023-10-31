using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSpawn : Singleton<DiceSpawn>
{
    [SerializeField] public Dice[] dice;
    [SerializeField] public DiceBlock[] blocks;
    [SerializeField] public Transform[] blockTrans;

    int spawnCnt = 0;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void OnCreateDice()
    {

        if(true)
        {
            for(int i = 0; i < blocks.Length; i++) 
            {
                int rand = Random.Range(0, blocks.Length);
                int diceRand = Random.Range(0, dice.Length);
                Vector3 createPos = blocks[rand].transform.position;
                if (blocks[rand].isDice == false)
                {
                    //Dice d = Instantiate(dice[diceRand], createPos, Quaternion.identity);
                    //d.transform.SetParent(blockTrans[rand].transform);  
                    blocks[rand].dice = Instantiate(dice[diceRand], createPos, Quaternion.identity);                   
                    blocks[rand].isDice = true;
                    //blocks[rand].dice = blocks[i].dice;
                    spawnCnt++;
                    break;
                }
            }
        }
    }
}
