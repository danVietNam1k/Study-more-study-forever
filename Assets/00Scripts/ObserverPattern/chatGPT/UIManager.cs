using UnityEngine;

public class UIManager : MonoBehaviour
{
    void OnEnable()
    {
        Player.OnPlayerDead += ShowGameOver;
    }

    void OnDisable()
    {
        Player.OnPlayerDead -= ShowGameOver;
    }

    void ShowGameOver()
    {
        Debug.Log("UI: Game Over screen");
    }
}
