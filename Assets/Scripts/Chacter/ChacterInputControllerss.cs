using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChacterInputControllerss : MonoBehaviour
{
    private float horizontalValue;
     public float HorizontalValue 
    {
        get { return horizontalValue ;}
    }

    [SerializeField] private float forwardMomentSpeed;
    [SerializeField] private float horizontalMomentSpeed;
    [SerializeField] private float horizontalLimitValue;

    
    private void FixedUpdate()
    {
        SetHeroMomentSpeed();
        SetHorizontalMoment();
    }

    protected virtual void SetHeroMomentSpeed()
    {
        transform.Translate(Vector3.forward * forwardMomentSpeed * Time.fixedDeltaTime);
    }

    protected virtual void Update()
    {
        HorizontalValueInput();
    }

    private void HorizontalValueInput()
    {
        if(Input.GetMouseButton(0))
        {
              horizontalValue = Input.GetAxis("Mouse X");
        }
        else
        {
            horizontalValue = 0;
        }

    }

    void SetHorizontalMoment()
    {
        float newPositionX;
        newPositionX = transform.position.x + HorizontalValue * horizontalMomentSpeed * Time.fixedDeltaTime;
        newPositionX = Mathf.Clamp( newPositionX ,-horizontalLimitValue , horizontalLimitValue);
        transform.position = new Vector3(newPositionX , transform.position.y,transform.position.z);
    }
}
