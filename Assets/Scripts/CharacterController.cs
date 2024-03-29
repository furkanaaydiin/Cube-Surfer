using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class CharacterController : MonoBehaviour
    {
        public static CharacterController Instance;
        private float HorizontalValue => horizontalValue;
        private  float horizontalValue;
        [SerializeField] private float forwardSpeed;
        [SerializeField] private float horizontalSpeed;
        [SerializeField] private float horizontalLimitValue;

        private void Awake()
        {
            Instance = this;
        }

        private void FixedUpdate()
        {
            if (!GameManager.IsMove) return;
            SetHeroMomentSpeed();
            SetHorizontalMoment();
            HorizontalValueInput();

        }
     
        private void SetHeroMomentSpeed()
        {
            transform.Translate(Vector3.forward * (forwardSpeed * Time.fixedDeltaTime));
            CharacterAnimation.Instance.RunAnimation();
            if (!GameManager.GameOver) return;
            {
                GameOverValue();
            }
        }

        public void GameOverValue()
        {
            forwardSpeed = 0;
            horizontalSpeed = 0f;
        }
            
        
        private void HorizontalValueInput()
        {
            if(Input.GetMouseButton(0))
                horizontalValue = Input.GetAxis("Mouse X");
            else
                horizontalValue = 0;

        }

        private void SetHorizontalMoment()
        {
            var newPositionX = transform.position.x + HorizontalValue * horizontalSpeed * Time.fixedDeltaTime;
            newPositionX = Mathf.Clamp( newPositionX ,-horizontalLimitValue , horizontalLimitValue);
            transform.position = new Vector3(newPositionX , transform.position.y,transform.position.z);
        }
  
    }
}
