using System;
using UnityEngine;
using DG.Tweening;

namespace Character
{
    public class FinishCameraRotate : MonoBehaviour
    {
        public static FinishCameraRotate Instance;
        [SerializeField] private Transform rotateObject;
        [SerializeField] private float duration;

        private void Awake()
        {
            Instance = this;
        }

        public void FinishRotateCam()
        {
            rotateObject.DOLocalRotate(new Vector3(0, 360, 0), duration, RotateMode.LocalAxisAdd).SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Incremental);
        }
    }
}