using System;
using System.Collections.Generic;
using Game.LightTools;
using Unity.Mathematics;
using UnityEngine;

namespace LightHorse.LightTools.Mono
{
    public partial class Spot_Mono:MonoBehaviour,ICanGetRay,ICanShootRay
    {
        private bool _hasray;
        public bool HasRay => _hasray;
        
        private Transform _shoot;
        public Transform Shoot => _shoot;
        
        private RayData _rayData;
        public RayData RayData => _rayData;

        private List<ILight> lights = new List<ILight>();
        private void Start()
        {
            _shoot = transform.GetChild(0);
        }   

        private void Update()
        {
            if (_hasray)
            {
                TrggerRay(-transform.up, _shoot.position,BlendRay(lights) );
                _hasray = false;
            }
            lights.Clear();
        }
        
    }

    public partial class Spot_Mono
    {
        ILight BlendRay(List<ILight> lights)
        {
            //依次为红绿蓝的数量
            int[] data = new[] { 0, 0, 0 };
            foreach (var light in lights)
            {
                foreach (var oc in light.Colors)
                {
                    switch (oc)
                    {
                       case Orgin_Light.Red:
                           data[0]++;
                           break;
                       case Orgin_Light.Green:
                           data[1]++;
                           break;
                       case Orgin_Light.Blue:
                           data[2]++;
                           break;
                    }
                }
            }
            //---------返回白光————————
            if((data[0]==data[1])&&(data[1]==data[2]))
            {
                return new WhiteLight();
            }
            else if((data[0]==data[1])&&(data[0]>data[2]))
            {
                return new YellowLight();
            }
            else if ((data[0] == data[1]) && (data[0] < data[2]))
            {
                return new BlueLight();
            }
            else if ((data[1] == data[2]) && (data[0] < data[2]))
            {
                return new QinLight();
            }
            else if ((data[1] == data[2]) && (data[0] > data[2]))
            {
                return new RedLight();
            }
            else if ((data[0] == data[2]) && (data[0] < data[1]))
            {
                return new GreenLight();
            }
            else if ((data[0] == data[2]) && (data[0] > data[1]))
            {
                return new PinkLight();
            }
            else if((data[0] > data[2]) && (data[0] > data[1]))
            {
                return new RedLight();
            }
            
            else if((data[1] > data[2]) && (data[0] < data[1]))
            {
                return new GreenLight();
            }
            
            else if((data[0] < data[2]) && (data[2] > data[1]))
            {
                return new BlueLight();
            }
            Debug.LogError("颜色配比错误"+data[0] +" "+data[1]+" "+data[2]);
            return new WhiteLight();
        }
        
        public void GetRay(Transform sender, ILight light, Vector2 point)
        {
            _hasray = true;
            _rayData.Sender = sender;
            _rayData.Light = light;
            _rayData.Point = point;
            
            lights.Add(light);
        }
        public void TrggerRay(Vector2 direct, Vector2 shootpos, ILight light)
        {
//            Debug.Log(light+"wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww");
        //    Debug.DrawRay(shootpos,direct,Color.yellow);
            
            var hit2D = Physics2D.Raycast(shootpos, direct);
            
            //如果没有检测到物体就返回
            if (!hit2D)
            {
                return;
            }
            
            //检测到可吸收光的物体后的操作
            if(hit2D.transform.TryGetComponent<ICanGetRay>(out var mono))
            {
                //使射线检测到的物体状态转换为被光照状态
                mono.GetRay(transform,light,hit2D.point);
                //Debug.LogWarning("已连接"+hit2D.transform.name);
         
              //  Debug.LogWarning("连线");
                //连线
                ShowLight.Showlight(light,shootpos,hit2D.point);
             //   Debug.DrawLine(shootpos,hit2D.point,Color.green);
                //    Debug.Log(hit2D.point + ":"+hit2D.transform.gameObject);
            }
        }
    }
}