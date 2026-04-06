using UnityEngine;
namespace ChatGPT {
    /// <summary>
    /// Class gameplay sử dụng service
    /// </summary>
    public class Player : MonoBehaviour
    {
        private IAudioSystem audioSystem;

        private void Awake()
        {
            // Lấy service (không throw exception)
            if (!ServiceLocator.TryGet(out audioSystem))
            {
                Debug.LogError("AudioSystem not available");
            }
        }

        private void Start()
        {
            // Sử dụng service
            audioSystem?.PlaySpawnSound();
        }
    }


}
