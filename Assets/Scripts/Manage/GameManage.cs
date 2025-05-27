using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Game.LightTools;
using Game.Plant;
using Game.Plant.Mono;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public List<PlantA> Plants;

    private void Awake()
    {
        Plants = FindObjectsOfType<PlantA>().ToList();
    }

    private void Update()
    {
        GetEnergy();
        if (IsSuccess())
        {
            OnSuccess();
        }
    }
    void OnSuccess()
    {
        var a =  FindObjectOfType<UI_Manage>();
        if (!a.SuccessUI.activeSelf)
        {
            a.SuccessUI.SetActive(true);
        }
    }
    
    bool IsSuccess()
    {
        foreach (var plant in Plants)
        {
            if (!(plant.Grade > 0))
                return false;
        }
        return true;
    }
    
    void GetEnergy()
    {
        foreach (var plant in Plants)
        {
            Debug.Log(plant.HasRay);
            if (!plant.IsGrowing)
            {
                foreach (var p in Plants)
                {
                    Debug.Log("可以");
                    p.CanSuccess = false;
                }
                return;   
            }
        }
        foreach (var p in Plants)
        {
            Debug.Log("可以");
            p.CanSuccess = true;
        }
    }
    
}
