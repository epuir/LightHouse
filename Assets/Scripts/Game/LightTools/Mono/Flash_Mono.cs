using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.LightTools;
using UnityEngine;

namespace LightHorse.LightTools.Mono
{
    public partial class Flash_Mono:MonoBehaviour,ICanShootRay,ICanGetRay
    {
        private bool _hasray;
        public bool HasRay => _hasray;

        private Transform _shoot;
        public Transform Shoot => _shoot;
        
        private List<ILight> _rayData = new List<ILight>();
        public List<ILight> RayData => _rayData;

        private int Idex = 0;
        private void Awake()
        {
            _shoot = transform.GetChild(0);
            AddIndex();
        }

        private void Update()
        {
            if (_hasray&&_rayData.Count != 0)
            {
                
                int i = Idex%_rayData.Count;
                TrggerRay(-transform.up, _shoot.transform.position,_rayData[i]);
                _hasray = false;
            }
        }
        

        private void LateUpdate()
        {
            _rayData.Clear();
        }
    }

    partial class Flash_Mono
    {
        public void GetRay(Transform sender, ILight light, Vector2 point)
        {
            _hasray = true;
            if (!_rayData.Contains(light))
            {
                _rayData.Add(light);
            }

            foreach (var l in _rayData)
            {
                Debug.Log(l);
            }
            
        }
        
        public void TrggerRay(Vector2 direct, Vector2 shootpos, ILight light)
        {
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
                //连线
                ShowLight.Showlight(light,shootpos,hit2D.point);
            }
        }


        private async void AddIndex()
        {
            while (true)
            {
                await UniTask.WaitForSeconds(0.4f);
                Idex++;
            }
        }
    }
    
}