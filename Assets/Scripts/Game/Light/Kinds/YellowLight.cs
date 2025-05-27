using System.Collections.Generic;

namespace LightHorse
{
    public class YellowLight:ILight
    {
        private List<Orgin_Light> _colors = new List<Orgin_Light>() { Orgin_Light.Red ,Orgin_Light.Green};
        public  IReadOnlyList<Orgin_Light> Colors => _colors;
        
        public ILight[] Dispersion()
        {
            return new[] { new GreenLight(),(ILight)Clone(),new RedLight()};
        }
        
        public ILight Reflex()
        {
            return (ILight)Clone();
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}