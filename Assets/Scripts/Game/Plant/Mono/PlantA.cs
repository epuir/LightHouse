using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Game.LightTools;
using LightHorse;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Plant.Mono
{
    public partial class PlantA:MonoBehaviour,IPlant,ICanGetRay,ICanUpgrade
    {
        private HashSet<Type> _needLights;
        public IReadOnlyList<Type> NeedLight => _needLights.ToList();

        private HashSet<Type> _hasLights = new HashSet<Type>();
        public IReadOnlyList<Type> HasLights => _hasLights.ToList();

        private bool _isgrowing;
        public bool IsGrowing => _isgrowing;

        private bool _hasray;
        public bool HasRay => _hasray;

        private bool _cangrow;
        public bool CanGrow => _cangrow;
        
        private int _growvalue;
        public int GrowValue => _growvalue;

        private int _goalvalue = 50;
        public int GoalValue => _growvalue;

        private int _grade;
        public int Grade => _grade;

        public bool CanSuccess ;
        
        //植物需要的光线
        [SerializeField]
        private List<LightKinds> _lightkind;
        
        //UI层
        [SerializeField]
        private Slider _slider;


        private void Awake()
        {
            _needLights = PlantneedRay.GetRayNeedKinds(_lightkind);
            Debug.Log(_needLights.Count);
        }

        private void Update()
        {
            _slider.value = _growvalue/(float)_goalvalue;
            //UI层
            ClearLights();
            if (_hasray)
            {
                _hasray = false;
                if (!_isgrowing)
                {
                    _cangrow = true;
                    _isgrowing = true;
                    Debug.Log("植物预备开始冲光");
                    GrowUp();
                }
            }
            else
            {
                _cangrow = false;
                _isgrowing = false;
            }
        }
        
    }

    public partial class PlantA
    {
        bool JidgeLights(HashSet<Type> n,HashSet<Type> h)
        {
            if (n.SetEquals(h))
            {
                return true;
            }

            return false;
        }
        
        public void OnGrowUp(int grade)
        {
            Debug.Log("目前等级"+grade);
            GetComponent<SpriteRenderer>().color = Color.black;
            Debug.Log("植物成功Success!!!!!!!!");
        }
        public async void GrowUp()
        {
            await UniTask.WaitUntil(() => { return CanSuccess;});
            if (_growvalue >= _goalvalue)
            {
                return;
            }
            while (_growvalue<_goalvalue)
            {
                if (!_cangrow&&!CanSuccess)
                {
                    _growvalue = 0;
                    Debug.Log("取消冲光");
                   return;
                }
                await UniTask.WaitForSeconds(0.1f);
                _growvalue++;
                Debug.Log((float)_growvalue/_goalvalue);
            }
            _grade++;
            OnGrowUp(_grade);
        }

        public void GetRay(Transform sender, ILight light, Vector2 point)
        {
            _hasLights.Add(light.GetType());
            if(JidgeLights(_needLights,_hasLights))
                _hasray = true;
        }

        async void ClearLights()
        {
            await UniTask.WaitForEndOfFrame();
            _hasLights.Clear();
        }
    }
    
    
}