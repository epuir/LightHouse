using System.Collections;
using System.Collections.Generic;
using LightHorse;
using Unity.VisualScripting;
using UnityEngine;

public class LineRenderer_Manage : MonoBehaviour
{
   public void AddLight(ILight light,Vector2 start,Vector2 end)
   { 
      var line_light  = new GameObject("").transform;
      line_light.SetParent(transform);
      var line =line_light.AddComponent<LineRenderer>();
      line.widthMultiplier = 0.2f;
      line.SetPosition(0, start);
      line.SetPosition(1,end);
   }
}
