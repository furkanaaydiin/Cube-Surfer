using System.Net.Mime;
using UnityEngine;
using TMPro;
using Button = UnityEngine.UI.Button;
using DG.Tweening;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    public static UIController Instance;
    [SerializeField] private Button tapToStartButton;
    [SerializeField] private TextMeshPro characterScoreText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        tapToStartButton.onClick.AddListener(TapToStart);
    }
    private void TapToStart()
    {
        GameManager.isMove = true;
        tapToStartButton.gameObject.transform.DOScale(Vector3.one * 0f, 1f).SetEase(Ease.Linear).OnComplete( 
            () => Destroy(tapToStartButton.gameObject));
    }

    public void CharacterScoreText()
    {
        characterScoreText.DOFade(1f, 1f).OnComplete(() =>

            characterScoreText.DOFade(0f,1f)

        );
    }
    
}
