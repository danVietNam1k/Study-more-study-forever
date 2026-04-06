using UnityEngine;

public class SoundManager : MonoBehaviour
{
    void OnEnable()
    {
        Player.OnPlayerDead += PlayDeathSound;
    }

    void OnDisable()
    {
        Player.OnPlayerDead -= PlayDeathSound;
    }

    void PlayDeathSound()
    {
        Debug.Log("Sound: play death sound");
    }
}