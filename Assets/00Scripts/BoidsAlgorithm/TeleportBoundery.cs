using UnityEngine;

public class TeleportBoundery : MonoBehaviour
{
    [SerializeField] private Boundery boundery;
    private void FixedUpdate()
    {
        // X-axis check: If the absolute value of transform.position.x exceeds the X(XLimit) limit,
        // the object will be repositioned to the opposite side of the equivalent limit.
        if (Mathf.Abs(transform.position.x)> boundery.XLimit)
        {
            if (transform.position.x > 0)
            {
                transform.position = new Vector3(-boundery.XLimit, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(boundery.XLimit, transform.position.y, transform.position.z);

            }
        }
        // similar to above but on the Y-asix
        if (Mathf.Abs(transform.position.y) > boundery.YLimit)
        {
            if (transform.position.y > 0)
            {
                transform.position = new Vector3(transform.position.x, -boundery.YLimit, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, boundery.YLimit, transform.position.z);

            }
        }

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
