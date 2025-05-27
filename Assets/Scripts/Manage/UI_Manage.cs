using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manage : MonoBehaviour
{
   public const string Level = "LEVEL";
   public static int curr_Level
   {
      get
      {
         if (!PlayerPrefs.HasKey(Level))
            PlayerPrefs.SetInt(Level, 1);
         return PlayerPrefs.GetInt(Level);
      }
      set
      {
         PlayerPrefs.SetInt(Level, value);
      }
   }
   

   public GameObject SuccessUI;
   public void StartGame()
   {
      
      SceneManager.LoadSceneAsync(curr_Level);
   }
   
   
   public void ReturnMain()
   {
      SceneManager.LoadSceneAsync(0);
      curr_Level = 1;
   }
   public void Exit()
   {
      Application.Quit();
   }

   public void Next()
   {
      curr_Level++;
      Debug.Log(curr_Level);
      SceneManager.LoadSceneAsync(curr_Level);
   }

   public void RePlay()
   {
      SceneManager.LoadSceneAsync(curr_Level);
   }
}
