using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform chacter;
    [SerializeField] private float lerpValue;
    private  Vector3 mesafe;
    private Vector3 newPosition;

    void Start()
    {
        mesafe = transform.position - chacter.position;
    }

    
    private void LateUpdate()
    {
        setCameraFollow();
    }

    private void setCameraFollow()
    {
        newPosition =  Vector3.Lerp(transform.position ,new Vector3(0f,chacter.position.y,chacter.position.z) + mesafe,lerpValue * Time.deltaTime);
        transform.position = newPosition;
    }

} 
