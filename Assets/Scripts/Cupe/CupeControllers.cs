 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupeControllers : MonoBehaviour
{
public BoxCollider boxCollider;    
public bool isCollected = false;


private void FixedUpdate()
{
    SetCupeRaycastHit();
}
private void SetCupeRaycastHit()
{
    if(!isCollected) return;
    var bounds = ChacterCupeStack.instance.GetStackBounds();
    var hit = Physics.BoxCast( bounds.center,bounds.extents,Vector3.forward,out var m_Hit,Quaternion.identity,(bounds.extents/2).z);
    Debug.DrawRay(bounds.center,Vector3.forward,Color.black,1f);
    if(hit)
    {
        if(m_Hit.collider.CompareTag("Cube"))
        {
                ChacterCupeStack.instance.IncreaseCupeStack(m_Hit.collider.GetComponent<CupeControllers>());
                
        }
        else if(m_Hit.collider.CompareTag("Obstacle"))
        {
            ChacterCupeStack.instance.DacreaseCupeStack(this);
            
           
          
        }
    }
}
//  private Coroutine hizalaCorontine;
//     IEnumerator hizala()
//     {
        
//         while(true)
//         {
//         yield return new WaitForSeconds(1);
        
//         for(int i =0 ; i<cupelist.Count;i++)
//         {
//             cupelist[i].transform.localPosition = Vector3.up*0.5f;
//         }  
//         }  
         
    //}

}
