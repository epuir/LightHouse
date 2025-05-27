using LightHorse;
using UnityEngine;

namespace Game.LightTools
{
    public interface ICanGetRay
    {
        void GetRay(Transform sender,ILight light,Vector2 point);
        bool HasRay { get; }
    }
}