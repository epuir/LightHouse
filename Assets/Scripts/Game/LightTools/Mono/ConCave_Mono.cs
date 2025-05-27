using System;
using Cysharp.Threading.Tasks;
using Game.LightTools;
using LightHorse;
using LightHorse.LightTools;
using UnityEngine;

public partial class ConCave_Mono : MonoBehaviour, ICanGetRay, ICanShootRay
{
   [SerializeField] private bool hasRay;


   public bool HasRay => hasRay;

   private Transform _shoot;
   public Transform Shoot => _shoot;
   
   //接受光线的信息
   private RayData _rayData;
   public RayData RayData => _rayData;

   private RaycastHit2D hit2D;
   
   private int IsZ = 1;
   

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

public partial class ConCave_Mono
{
   //凸透镜发射光线的方法
   void ShootRay()
   {
      Vector3 down = (_shoot.position - transform.position).normalized;
      down = new Vector3(down.x, down.y * IsZ, down.z);
      Vector3 right = Quaternion.Euler(0, 0, 45) * down;
      Vector3 left = Quaternion.Euler(0, 0, -45) * down;
      var lights = _rayData.Light.Dispersion();
      TrggerRay(left,_shoot.position,lights[0]);
      TrggerRay(down,_shoot.position,lights[1]);
      TrggerRay(right,_shoot.position,lights[2]);
      hasRay = false;
   }
   
   
   
   
   
   //被光照射
   public void GetRay(Transform sender,ILight light,Vector2 point)
   {
      hasRay = true;
      _rayData.Sender = sender;
      _rayData.Light = light;
      _rayData.Point = point;
      //ShootRay();
   }
   
   
   
   //发射光线
   void ICanShootRay.TrggerRay(Vector2 direct,Vector2 shootpos,ILight light)
   {
      TrggerRay(direct,shootpos,light);
   }

   void TrggerRay(Vector2 direct,Vector2 shootpos,ILight light)
   {
     // Debug.DrawRay(_shoot.position, direct,Color.magenta);
      hit2D = Physics2D.Raycast(shootpos, direct);
      if (!hit2D)
      {
         return;
      }

      if(hit2D.transform.TryGetComponent<ICanGetRay>(out var mono))
      {
         mono.GetRay(transform,light,hit2D.point );
         //连线
         
         ShowLight.Showlight(light,_shoot.position,hit2D.point);
        // Debug.DrawLine(_shoot.position,hit2D.point);
      }
   }
}
