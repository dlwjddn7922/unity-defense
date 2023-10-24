using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataJson : MonoBehaviour
{
    public struct DiceDetailData
    {
        public string name;
        public int power;
        public float atkspeed;
        public string target;
        public int addpower;
        public int classuppower;
        public float classupspeed;
        public int classupaddpower;
        public int leveluppower;
        public float levelupspeed;
        public int levelupaddpower;
    }
    public struct DiceJsonData
    {
        public List<DiceDetailData> DiceData;
    }
    public DiceJsonData diceJsonData = new();
    [SerializeField] TextAsset diceDataTxt;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(JsonUtility.FromJson<DiceJsonData>(diceDataTxt.text));
    }

}
