using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataJson : Singleton<DataJson>
{
    [SerializeField] private TextAsset diceDataTxt;
    [SerializeField] private TextAsset monsterDataTxt;
    [SerializeField] private TextAsset stageDataTxt;

    #region Dice Data
    [System.Serializable]
    public class DiceDetailData
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
    [System.Serializable]
    public class DiceJsonData
    {
        public List<DiceDetailData> DiceData = new List<DiceDetailData>();
    }
    public DiceJsonData diceJsonData = new DiceJsonData();
    #endregion

    #region Monster Data
    [System.Serializable]
    public class MonsterDetailData
    {
        public string name;
        public int hp;
        public float speed;
    }
    [System.Serializable]
    public class MonsterJsonData
    {
        public List<MonsterDetailData> MonsterData = new List<MonsterDetailData>();
    }
    public MonsterJsonData monsterJsonData = new MonsterJsonData();
    #endregion
    #region Stage Data
    [System.Serializable]
    public class StageDetailData
    {
        public int min;
        public int max;
        public int count;
    }
    [System.Serializable]
    public class StageJsonData
    {
        public List<StageDetailData> StageData = new List<StageDetailData>();
    }
    public StageJsonData stageJsonData = new StageJsonData();

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(JsonUtility.FromJson<DiceJsonData>(diceDataTxt.text));
        Debug.Log(JsonUtility.FromJson<MonsterJsonData>(monsterDataTxt.text));
        Debug.Log(JsonUtility.FromJson<MonsterJsonData>(stageDataTxt.text));
        diceJsonData = JsonUtility.FromJson<DiceJsonData>(diceDataTxt.ToString());
        monsterJsonData = JsonUtility.FromJson<MonsterJsonData>(monsterDataTxt.ToString());
        stageJsonData = JsonUtility.FromJson<StageJsonData>(stageDataTxt.ToString());
    }

}
