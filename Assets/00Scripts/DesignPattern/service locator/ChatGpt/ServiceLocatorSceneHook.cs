using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Hook vào Unity lifecycle để auto clear ServiceLocator khi đổi scene
/// </summary>
namespace ChatGPT {
    public static class ServiceLocatorSceneHook
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Init()
        {
            // Subscribe event đổi scene
            SceneManager.activeSceneChanged += OnSceneChanged;
        }

        private static void OnSceneChanged(Scene oldScene, Scene newScene)
        {
            // Clear toàn bộ service → tránh memory leak
            ServiceLocator.Clear();
        }
    }
}

