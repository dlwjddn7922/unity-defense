using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSpawn : MonoBehaviour
{
    [SerializeField] private Dice[] dice;
    [SerializeField] private DiceBlock[] blocks;

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
