using UnityEngine;

namespace LightHorse.LightTools
{
    public interface ICanShootRay
    {
        Transform Shoot { get; }
        void TrggerRay(Vector2 direct,Vector2 shootpos,ILight light);
    }
}