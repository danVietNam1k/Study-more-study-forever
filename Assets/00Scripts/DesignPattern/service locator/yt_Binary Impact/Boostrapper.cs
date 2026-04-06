using UnityEngine;
[DefaultExecutionOrder(-1)]
public class Boostrapper : MonoBehaviour
{
    private void Awake()
    {
        ServiceLocator.Register(new AudioSystem());
    }
}
