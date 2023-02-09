using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCubeStack : MonoBehaviour
{
    public static CharacterCubeStack instance;
    [SerializeField] public  List<CubeController> cubeList = new();
    private  CubeController lowerCubeObject;
   
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateLowerObject();
    }

    public Bounds GetStackBounds()
    {
        var bounds = new Bounds(transform.position + cubeList[0].boxCollider.center,cubeList[0].boxCollider.size);
        foreach (var t in cubeList)
        {
            bounds.Encapsulate(t.boxCollider.bounds);
        }
        return bounds;
    }

    public  void IncreaseCubeStack(CubeController cubeController)
    {
        cubeController.tag = "Untagged";
        var position = transform.position;
        position = new Vector3(position.x,position.y + 0.5f,position.z);
        transform.position = position;
        
        var position1 = lowerCubeObject.transform.position;
        cubeController.transform.position = new Vector3(position1.x, position1.y - 1f, position1.z);
        cubeController.transform.SetParent(transform);
        cubeList.Add(cubeController);
        UpdateLowerObject();
        cubeController.isCollected = true;
    }

    public void DecreaseCubeStack(CubeController cubeController)
    {
        if(cubeController == cubeList[0]) return;
        cubeController.isCollected = false;
        cubeController.transform.parent = null;
        cubeList.Remove(cubeController);
        UpdateLowerObject();
        Destroy(cubeController.gameObject , 2f);
            
    }
    private void UpdateLowerObject()
    {
        lowerCubeObject = cubeList[cubeList.Count - 1];
         
    }

    
    
    // [System.Diagnostics.Conditional("UNITY_EDITOR")]
    // // private void OnDrawGizmos()
    // {
    //     var bounds = GetStackBounds();
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawCube(bounds.center,bounds.size);
    // }
}