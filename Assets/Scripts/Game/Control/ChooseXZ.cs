using System.Collections;
using System.Collections.Generic;
using LightHorse.LightTools;
using Unity.VisualScripting;
using UnityEngine;

public class ChooseXZ : MonoBehaviour
{
    public float TimeJudge = 0;
    private float Rspeed = 5f;
    public Vector3 FirstPosition;
    public Vector3 SecondPosition;
    
    private GameObject _planttool;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 v = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 d = (Vector2)v - (Vector2)transform.position;
            var hit2d = Physics2D.Raycast((Vector2)v, Vector2.zero);
            if (hit2d.transform == null||!hit2d.transform.TryGetComponent<ICanShootRay>(out var tool))
            {
                Debug.Log("没有物品");
                return;
            }
            Debug.Log(hit2d.transform.name);
            _planttool = hit2d.transform.gameObject;
        }

        if (Input.GetMouseButton(0)&&_planttool!=null)
        {
            if (Input.GetKey(KeyCode.E))
            {
                OnLeft();
            }
            
            if (Input.touchCount == 2)
            {
                Touch first = Input.GetTouch(0);
                Touch second = Input.GetTouch(1);

                if (second.phase == TouchPhase.Began)
                {
                    FirstPosition = first.position;
                    SecondPosition = second.position;
                }
               
                
                _planttool.transform.Rotate(0,0,-(second.position.y-SecondPosition.y)*Time.deltaTime*Rspeed);
                
                
                SecondPosition = second.position;
                FirstPosition = first.position;
                
                // if (Input.touches[0].position.y - Input.touches[1].position.y > 0)
                // {
                //     OnLeft();
                // }
                // else
                // {
                //     OnRight();
                // }
            }
            else
            {
                OnDrag();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _planttool = null;
            OnDragEnd();
        }
    }

    private void OnDragEnd()
    {
        Debug.Log("结束拖拽");
    }


    //点击的方法
    void Chick()
    {
        Debug.Log("点击");
    }

    //拖拽的方法
    void OnDrag()
    {
        Debug.Log("正在拖拽");
        
        var v = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _planttool.transform.position = v + new Vector3(0, 0, 10);
    }

    public void OnLeft()
    {
        _planttool.transform.Rotate(0,0,Time.deltaTime*Rspeed*10);
    }

    public void OnRight()
    {
        _planttool.transform.Rotate(0,0,Time.deltaTime*-Rspeed);
    }
}
