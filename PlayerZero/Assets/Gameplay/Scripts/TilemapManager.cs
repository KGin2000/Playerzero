using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapManager : SingletonMonobehaviour<TilemapManager>
{
    [SerializeField] public GameObject Pound;
    [SerializeField] public GameObject DryWaterLV1;
    [SerializeField] public GameObject DryWaterLV2;
    [SerializeField] public GameObject PoundSoil;

    private int IfDrought;

    void Start()
    {
        Pound.SetActive(true);
        DryWaterLV1.SetActive(false);
        DryWaterLV2.SetActive(false);
        PoundSoil.SetActive(false);
    }

    void Update()
    {
        IfDrought = GetValueDaily.Instance.Drought;
    }

    public void SetPoundTilemap()
    {
        if(IfDrought == 0)
        {
            Pound.SetActive(true);
            DryWaterLV1.SetActive(false);
            DryWaterLV2.SetActive(false);
            PoundSoil.SetActive(false);
        }
        else if (IfDrought == 1)
        {
            Pound.SetActive(false);
            DryWaterLV1.SetActive(true);
            DryWaterLV2.SetActive(false);
            PoundSoil.SetActive(true);
        }
        else if (IfDrought == 2)
        {
            Pound.SetActive(false);
            DryWaterLV1.SetActive(false);
            DryWaterLV2.SetActive(true);
            PoundSoil.SetActive(true);
        }
        else if (IfDrought == 3)
        {
            Pound.SetActive(false);
            DryWaterLV1.SetActive(false);
            DryWaterLV2.SetActive(false);
            PoundSoil.SetActive(true);
        }
    }
}
