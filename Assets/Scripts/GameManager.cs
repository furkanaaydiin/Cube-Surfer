using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager Instance;
    private bool İsMove => IsMove;
    public static bool IsMove;
    private bool gameOver => GameOver;
    public static bool GameOver;
    private bool isDead => IsDead;
    public static bool IsDead;

    private void Awake()
    {
        Instance = this;
    }
}
