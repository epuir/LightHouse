
using Game.LightTools;
using LightHorse;
using UnityEngine;

public class StartRay : MonoBehaviour
{
    private ILight w = new WhiteLight();
    private void Update()
    {
        var _hit =  Physics2D.Raycast(transform.position, Vector2.down);
        _hit.transform.GetComponent<ICanGetRay>().GetRay(transform,new WhiteLight(),_hit.point);
        ShowLight.Showlight(w,transform.position,_hit.point);
        //Debug.DrawLine(transform.position,_hit.point,Color.white);
    }
}
