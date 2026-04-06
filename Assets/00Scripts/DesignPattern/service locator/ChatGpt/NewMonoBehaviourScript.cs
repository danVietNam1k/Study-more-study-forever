namespace ChatGPT {
    using UnityEngine;

    /// <summary>
    /// Nơi duy nhất register tất cả service
    /// </summary>
    [DefaultExecutionOrder(-1000)] // chạy trước toàn bộ script khác
    public class Bootstrapper : MonoBehaviour
    {
        private void Awake()
        {
            // Giữ object này khi load scene
            DontDestroyOnLoad(gameObject);

            RegisterServices();
        }

        private void RegisterServices()
        {
            // Register qua interface (best practice)
            ServiceLocator.Register<IAudioSystem>(new AudioSystem());
        }
    }
}

