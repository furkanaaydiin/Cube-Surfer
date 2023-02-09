using UnityEngine;

namespace Character
{
    public class FinishPlatform : MonoBehaviour
    {

        [SerializeField] private MeshRenderer[] finishCubeRenderer;

        private Color[] finishPlatformColor =
        { 
            Color.green, Color.red, Color.yellow, Color.magenta, Color.blue,
            Color.green, Color.red, Color.yellow, Color.magenta, Color.blue,
        };

        private void Start()
        {
            for (var i = 0; i < finishCubeRenderer.Length; i++)
            { 
                var randomColor = finishPlatformColor[i];
                for (var j = 0; j < finishPlatformColor.Length; j++)
                {
                    finishCubeRenderer[i].material.color = randomColor;
                }
            }
        }
        
    }

}