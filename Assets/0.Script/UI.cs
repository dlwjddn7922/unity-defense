using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI : MonoBehaviour
{
    [SerializeField] public TMP_Text fireLv;
    [SerializeField] public TMP_Text elecLv;
    [SerializeField] public TMP_Text windLv;
    [SerializeField] public TMP_Text poisonLv;
    [SerializeField] public TMP_Text stillLv;
    [SerializeField] public Button fireButton;
    [SerializeField] public Button elecButton;
    [SerializeField] public Button windButton;
    [SerializeField] public Button poisonButton;
    [SerializeField] public Button stillButton;
    int firelv = 1;
    int eleclv = 1;
    int windlv = 1;
    int poisonlv = 1;
    int stilllv = 1;
    int maxlv = 30;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        fireLv.text = $"Lv.{firelv}";
        elecLv.text = $"Lv.{eleclv}";
        windLv.text = $"Lv.{windlv}";
        poisonLv.text = $"Lv.{poisonlv}";
        stillLv.text = $"Lv.{stilllv}";
        MaxLv();

    }
    public void OnClickFire()
    {
        firelv++;
        
    }
    public void OnClickElec()
    {
        eleclv++;
    }
    public void OnClickWind()
    {
        windlv++;
    }
    public void OnClickPoison()
    {
        poisonlv++;
    }
    public void OnClickStill()
    {
        stilllv++;
    }
    public void MaxLv()
    {
        if(firelv > maxlv)
        {
            fireLv.text = $"Lv.Max";
            fireButton.interactable = false;
        }
        if (eleclv > maxlv)
        {
            elecLv.text = $"Lv.Max";
            elecButton.interactable = false;
        }
        if (windlv > maxlv)
        {
            windLv.text = $"Lv.Max";
            windButton.interactable = false;
        }
        if (poisonlv > maxlv)
        {
            poisonLv.text = $"Lv.Max";
            poisonButton.interactable = false;
        }
        if (stilllv > maxlv)
        {
            stillLv.text = $"Lv.Max";
            stillButton.interactable = false;
        }
    }
}
