using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChacterMomentControllers : MonoBehaviour
{
    [SerializeField] private ChacterInputControllerss chacterInputControllerss;

    [SerializeField] private float forwardMomentSpeed;
    [SerializeField] private float horizontalMomentSpeed;
    [SerializeField] private float horizontalLimitValue;    

    private float newPositionX;
    void FixedUpdate()
    {
        SetHeroMomentSpeed();
        SetHorizontalMoment();
    }
    void SetHeroMomentSpeed()
    {
        transform.Translate(Vector3.forward * forwardMomentSpeed * Time.fixedDeltaTime);
    }
    void SetHorizontalMoment()
    {
       
        newPositionX = transform.position.x + chacterInputControllerss.HorizontalValue *horizontalMomentSpeed * Time.fixedDeltaTime;
        transform.position = new Vector3(newPositionX , transform.position.y,transform.position.z);
    }
}

