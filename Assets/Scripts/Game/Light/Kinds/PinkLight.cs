using System.Collections.Generic;

namespace LightHorse
{
    public class PinkLight:ILight
    {
        public object Clone()
        {
            return  MemberwiseClone();
        }
        
        private List<Orgin_Light> _colors = new List<Orgin_Light>() { Orgin_Light.Blue,Orgin_Light.Red };
        public  IReadOnlyList<Orgin_Light> Colors => _colors;
        public ILight[] Dispersion()
        {
            return new[] { (ILight)(new BlueLight()),(ILight)Clone(),new RedLight()};
        }
        
        public ILight Reflex()
        {
            return (ILight)Clone();
        }
    }
}