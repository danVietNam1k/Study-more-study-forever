using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] Vector2 speedValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float ranScaleValue = Random.Range(0.5f, 2f);
        this.transform.localScale = new Vector3(ranScaleValue, ranScaleValue, 1f);
       
        float ranSpeedValue = Random.Range(speedValue.x, speedValue.y);
        Vector2 ranDirectionValue = Random.insideUnitCircle;
        GetComponent<Rigidbody2D>().AddForce(ranSpeedValue * ranDirectionValue);

    }

    // Update is called once per frame
    void Update()
    {

        GetComponent<Rigidbody2D>().AddTorque(0.1f);

    }
}
