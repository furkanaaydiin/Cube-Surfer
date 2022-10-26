using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChacterCupeStack : MonoBehaviour
{
    public static ChacterCupeStack instance;
    public  List<CupeControllers> cupelist = new List<CupeControllers>();
    private  CupeControllers lowerCupeObject;
   
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        UpdateLowerObject();
    }
    public Bounds GetStackBounds()
    {
        Bounds bounds = new Bounds(transform.position + cupelist[0].boxCollider.center,cupelist[0].boxCollider.size);
        
        for(int i = 0;i < cupelist.Count;i++)
        {
            bounds.Encapsulate(cupelist[i].boxCollider.bounds);
        }
        return bounds;
        
    }
    public  void IncreaseCupeStack(CupeControllers _CupeControllers)
    {
        _CupeControllers.tag = "Untagged";
        transform.position = new Vector3(transform.position.x,transform.position.y + 0.5f,transform.position.z);
        _CupeControllers.transform.position = new Vector3 
        (lowerCupeObject.transform.position.x,
        lowerCupeObject.transform.position.y - 0.7f,
        lowerCupeObject.transform.position.z);
        _CupeControllers.transform.SetParent(transform);
        cupelist.Add(_CupeControllers);
        UpdateLowerObject();
        _CupeControllers.isCollected = true;
        hizala();  
    }

    private Coroutine hizalaCorontine;
    IEnumerator hizala()
    {
        while(true)
        {
        yield return new WaitForSeconds(1);
        
        for(int i =0 ; i<cupelist.Count;i++)
        {
            cupelist[i].transform.localPosition = Vector3.up*0.5f;
        }  
        }  
         
    }

    public void DacreaseCupeStack(CupeControllers _CupeControllers)
    {
            if(_CupeControllers == cupelist[0]) return;
         _CupeControllers.isCollected = false;
            _CupeControllers.transform.parent = null;
            cupelist.Remove(_CupeControllers);
            UpdateLowerObject();
            
    }


    private void UpdateLowerObject()
    {
        lowerCupeObject = cupelist[cupelist.Count - 1];
         
    }

    private void OnDrawGizmos()
    {
        var bounds = GetStackBounds();
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(bounds.center,bounds.size);
    }
}
