using UnityEngine;
using UnityEngine.SceneManagement;
namespace ChatGPT { 

    /// <summary>
    /// Implementation thực tế của Audio System
    /// </summary>
    public class AudioSystem : IAudioSystem, IService
    {
        private AudioSource audioSource;

        public void Initialize()
        {
            // Tạo GameObject runtime (không cần đặt trong scene)
            var go = new GameObject("[AudioSystem]");

            // Không bị destroy khi load scene
            Object.DontDestroyOnLoad(go);

            // Add AudioSource để phát âm thanh
            audioSource = go.AddComponent<AudioSource>();
        }

        public void Dispose()
        {
            // Cleanup khi bị unregister hoặc clear
            if (audioSource != null)
            {
                Object.Destroy(audioSource.gameObject);
            }
        }

        public void PlaySpawnSound()
        {
            Debug.Log("Spawn Sound");
            // audioSource.PlayOneShot(...)
        }

        public void PlayDespawnSound()
        {
            Debug.Log("Despawn Sound");
        }
    }
}

