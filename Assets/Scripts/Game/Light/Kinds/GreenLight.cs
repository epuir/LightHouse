using System.Collections.Generic;

namespace LightHorse
{
    public class GreenLight:ILight
    {
        private List<Orgin_Light> _colors = new List<Orgin_Light>() { Orgin_Light.Green };
        public  IReadOnlyList<Orgin_Light> Colors => _colors;
        
        public ILight[] Dispersion()
        {
            return new[] { (ILight)Clone(),(ILight)Clone(),(ILight)Clone()};
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