using Game.LightTools;
using UnityEngine;

namespace LightHorse.LightTools.Mono
{
    public class Wall_Mono:MonoBehaviour,ICanGetRay
    {
        public bool HasRay { get; }
        public void GetRay(Transform sender, ILight light, Vector2 point)
        {
        }

        
    }
}