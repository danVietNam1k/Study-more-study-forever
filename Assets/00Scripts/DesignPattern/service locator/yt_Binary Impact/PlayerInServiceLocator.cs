using UnityEngine;

public class PlayerInServiceLocator : MonoBehaviour
{
   private IAudioSystem audioSystem;
    private void Awake()
    {
        audioSystem = ServiceLocator.Get<IAudioSystem>();
    }
    private void Start()
    {
        audioSystem.PlaySpawnSound();
    }
}
