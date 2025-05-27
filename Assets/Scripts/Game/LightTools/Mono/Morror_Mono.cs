using System;
using System.Collections.Generic;
using Game.LightTools;
using UnityEngine;

namespace LightHorse.LightTools.Mono
{
    public partial class Morror_Mono: MonoBehaviour,ICanGetRay,ICanShootRay
    {
        [SerializeField]
        private bool hasRay;
        public bool HasRay => hasRay;
   
        //负责发射的字物体
        private Transform _shoot;
        public Transform Shoot => _shoot;
        
        
        //接受光线的信息
        private List<RayData> _rayData = new List<RayData>();
        public List<RayData> RayData => _rayData;

        private RaycastHit2D hit2D;
        
        private void Awake()
        {
            _shoot = transform.GetChild(0);
        }

        private void Update()
        {
            if (hasRay)
            {
                ShootRay();
            }
        }
        
    }
    public partial class Morror_Mono
    {
        //镜子反射光线
        void ShootRay()
        {
            List<RayData> test = new List<RayData>(_rayData);
//            Debug.Log(_rayData.Count);
            foreach (var r in test)
            {
                _shoot.position = r.Point;
                Vector2 incidentVector = ((Vector2)(r.Sender.position) - r.Point);
                Vector2 surfaceVector = transform.right;
                Vector2 dir = Vector2.Reflect(incidentVector,surfaceVector);
                
                //暂时先这样，后期光色系统之后完善
                TrggerRay(dir,r.Light.Reflex(),r.Point-((Vector2)transform.position - r.Point).normalized*0.01f);
                hasRay = false;
            }
            _rayData.Clear();
           
        }
        
        
        //被光照射
        public void GetRay(Transform sender,ILight light,Vector2 point)
        {
            hasRay = true;
            _rayData.Add(new RayData(){Sender = sender,Light = light,Point = point});
        }
        
        //发射光线
        void ICanShootRay.TrggerRay(Vector2 direct,Vector2 shootpos,ILight light)
        {
            TrggerRay(direct,light,shootpos);
        }

        void TrggerRay(Vector2 direct,ILight light,Vector2 shootpos)
        {
          //  Debug.DrawRay(shootpos, direct,Color.magenta);
            hit2D = Physics2D.Raycast(shootpos, direct);
            
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
                
                //连线
                ShowLight.Showlight(light,shootpos,hit2D.point);
            //    Debug.DrawLine(shootpos,hit2D.point,Color.green);
            //    Debug.Log(hit2D.point + ":"+hit2D.transform.gameObject);
            }
        }
    }
}