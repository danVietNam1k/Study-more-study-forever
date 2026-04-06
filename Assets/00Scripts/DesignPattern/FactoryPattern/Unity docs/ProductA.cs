using UnityEngine;

public class ProductA : MonoBehaviour, IProduct
{
    [SerializeField] private string productName = "ProductA";
    public string ProductName { get => productName; set => productName = value;}
    private ParticleSystem particleSystem;
    public void Initialize()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
        gameObject.name = productName;
        particleSystem?.Stop();
        particleSystem?.Play();
    }
}
