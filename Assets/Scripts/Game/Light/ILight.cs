using System;
using System.Collections.Generic;

namespace LightHorse
{
    
    public interface ILight:ICloneable
    {
        IReadOnlyList<Orgin_Light> Colors { get; }
        public ILight[] Dispersion();
        public ILight Reflex();
    }
    public enum Orgin_Light
    {
        Red,
        Blue,
        Green
    }

    
}


