using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private ListBoidVariable boids;
    [SerializeField] private GameObject boidPrefab;
    [SerializeField] private float boidCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(boids.boidMovements.Count > 0) boids.boidMovements.Clear();
        for (int i = 0; i < boidCount; i++)
        {
            float direction = Random.Range(0f, 360f);
            Vector3 position = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
            Quaternion ranQua = Quaternion.Euler(Vector3.forward * direction) * boidPrefab.transform.localRotation;
            GameObject boid = Instantiate(boidPrefab, position, ranQua);
            boid.transform.SetParent(this.transform);
            boids.boidMovements.Add(boid.GetComponent<BoidMovement>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
