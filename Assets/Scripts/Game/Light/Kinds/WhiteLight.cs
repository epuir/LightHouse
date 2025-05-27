using System.Collections.Generic;

namespace LightHorse
{
    public class WhiteLight:ILight
    {
        private List<Orgin_Light> _colors = new List<Orgin_Light>() { Orgin_Light.Red,Orgin_Light.Blue,Orgin_Light.Green };
        public  IReadOnlyList<Orgin_Light> Colors => _colors;
        
        public ILight[] Dispersion()
        {
            return new[] { new RedLight(),new GreenLight(),(ILight)(new BlueLight())};
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