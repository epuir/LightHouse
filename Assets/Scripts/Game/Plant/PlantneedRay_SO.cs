using System;
using System.Collections;
using System.Collections.Generic;
using LightHorse;
using UnityEngine;

[CreateAssetMenu]
public static class PlantneedRay
{
    
    public static HashSet<Type> GetRayNeedKinds(List<LightKinds> lightneedkinds)
    {
        HashSet<Type> lightstype = new HashSet<Type>();
        foreach (var lightkind in lightneedkinds)
        {
            switch (lightkind)
            {
                case LightKinds.White:
                    lightstype.Add(typeof(WhiteLight));
                    break;
                case LightKinds.Red:
                    lightstype.Add(typeof(RedLight));
                    break;
                case LightKinds.Green:
                    lightstype.Add(typeof(GreenLight));
                    break;
                case LightKinds.Blue:
                    lightstype.Add(typeof(BlueLight));
                    break;
                case LightKinds.Pink:
                    lightstype.Add(typeof(PinkLight));
                    break;
                case LightKinds.Yellow:
                    lightstype.Add(typeof(YellowLight));
                    break;
                case LightKinds.Qin:
                    lightstype.Add(typeof(QinLight));
                    break;
            }
        }
        return lightstype;

    }
    
}
public enum LightKinds
{
    White,
    Red,
    Blue,
    Green,
    Qin,
    Pink,
    Yellow,
}
