using System.Collections.Generic;

namespace LightHorse
{
    public class QinLight:ILight
    {
        private List<Orgin_Light> _colors = new List<Orgin_Light>() { Orgin_Light.Blue,Orgin_Light.Green };
        public  IReadOnlyList<Orgin_Light> Colors => _colors;
        
        
        public ILight[] Dispersion()
        {
            return new[] { (ILight)(new BlueLight()),(ILight)Clone(),new GreenLight()};
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