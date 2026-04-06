using UnityEngine;

public class AnalyticsManager : MonoBehaviour
{
    void OnEnable()
    {
        Player.OnPlayerDead += SendAnalytics;
    }

    void OnDisable()
    {
        Player.OnPlayerDead -= SendAnalytics;
    }

    void SendAnalytics()
    {
        Debug.Log("Analytics: player death recorded");
    }
}