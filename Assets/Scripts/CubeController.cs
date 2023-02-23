using UnityEngine;
using System.Collections;
using Cameraa;
using Character;
using CameraType = Cameraa.CameraType;
using CharacterController = Character.CharacterController;

public class CubeController : MonoBehaviour
{
public BoxCollider boxCollider;    
public bool isCollected;

private void FixedUpdate()
{
    SetCubeRaycastHit();
}

private void SetCubeRaycastHit()
{
    if (!isCollected) return;
    var bounds = CharacterCubeStack.instance.GetStackBounds();
    var hit = Physics.BoxCast(bounds.center, bounds.extents, Vector3.forward, out var m_Hit, Quaternion.identity,
        (bounds.extents / 2).z);
    // Debug.DrawRay(bounds.center,Vector3.forward,Color.black,1f);
    if (!hit) return;
    if (m_Hit.collider.CompareTag("Cube"))
    {
        CharacterCubeStack.instance.IncreaseCubeStack(m_Hit.collider.GetComponent<CubeController>());
        UIController.Instance.CharacterScoreText();
        ScoreCounter.Instance.AddScore(10);
    }
    else if (m_Hit.collider.CompareTag("Obstacle"))
    {
        if (CharacterCubeStack.instance.cubeList.Count <= 1)
        {
            CharacterAnimation.Instance.animator.enabled = false;
            GameManager.IsDead = true;
        }

        CharacterCubeStack.instance.DecreaseCubeStack(this);
    }
    else if (m_Hit.collider.CompareTag("Diamond"))
    {
        ScoreCounter.Instance.AddDiamond(1);
        Destroy(m_Hit.collider.gameObject);
    }
    else if (m_Hit.collider.CompareTag("Finish"))
    {
        CharacterCubeStack.instance.DecreaseCubeStack(this);
        if (CharacterCubeStack.instance.cubeList.Count <= 1)
        {
            CharacterAnimation.Instance.WinAnimation(); 
            StartCoroutine(GameOverValueCoroutine()); 
            CameraController.Instance.ChangeCamera(CameraType.FinishCamera); 
            FinishCameraRotate.Instance.FinishRotateCam(); 
            GameManager.GameOver = true;
        }
        
    }

}
private IEnumerator GameOverValueCoroutine()
{
        
    yield return new WaitForSeconds(1f);
    CharacterController.Instance.GameOverValue();
}

}


