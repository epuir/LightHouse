using System;
using System.Collections.Generic;
using LightHorse;

namespace Game.Plant
{
    public interface IPlant
    {
        bool IsGrowing { get; }
        IReadOnlyList<Type> NeedLight { get; }
        void GrowUp();
        
    }
}