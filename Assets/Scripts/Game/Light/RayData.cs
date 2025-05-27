using UnityEngine;

namespace LightHorse
{
    public struct RayData
    {
        private Transform _sender;

        public Transform Sender
        {
            get { return _sender;}
            set { _sender = value; }
        }
        
        
        private ILight _light;

        public ILight Light
        {
            get { return _light;}
            set { _light = value; }
        }

        private Vector2 _point;

        public Vector2 Point
        {
            get { return _point; }
            set { _point = value; }
        }
        public RayData(Transform sender,ILight light,Vector2 point)
        {
            _point = point;
            _sender = sender;
            _light = light;
        }
    }
}