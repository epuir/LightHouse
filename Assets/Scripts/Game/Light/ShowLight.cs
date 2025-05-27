using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace LightHorse
{
    public static class ShowLight
    {
        /// <summary>
        /// 光线出现
        /// </summary>
        /// <param name="light">光的类型</param>
        /// <param name="start">光的开始点</param>
        /// <param name="end">光的结束点</param>
        async static void DestoryRat(GameObject g)
        {
            await UniTask.WaitForEndOfFrame();
            GameObject.Destroy(g);
        }
        public static void Showlight(ILight light,Vector2 start,Vector2 end)
        {
                var ray =  GameObject.Instantiate(Resources.Load<GameObject>("Ray")).GetComponent<LineRenderer>();
                DestoryRat(ray.gameObject);
                ray.SetPosition(0,start);
                ray.SetPosition(1,end);
                switch (light)
                {
                    case BlueLight _:
                        ray.startColor = ray.endColor = Color.blue;
                        Debug.DrawLine(start,end,Color.blue);
                        break;
                    case RedLight _:
                        ray.startColor = ray.endColor = Color.red;
                        Debug.DrawLine(start,end,Color.red);
                        break;
                    case GreenLight _:
                        ray.startColor = ray.endColor = Color.green;
                        Debug.DrawLine(start,end,Color.green);
                        break;
                    case PinkLight _:
                        ray.startColor = ray.endColor = Color.magenta;
                        Debug.DrawLine(start,end,Color.magenta);
                        break;
                    case WhiteLight _:
                        ray.startColor = ray.endColor = Color.white;
                        Debug.DrawLine(start,end,Color.white);
                        break;
                    case YellowLight _:
                        ray.startColor = ray.endColor = Color.yellow;
                        Debug.DrawLine(start,end,Color.yellow);
                        break;
                    case QinLight _:
                        ray.startColor = ray.endColor  = Color.cyan;
                        Debug.DrawLine(start,end,Color.cyan);
                        break;
                }
        }
    }
}