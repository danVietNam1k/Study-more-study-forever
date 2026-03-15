using UnityEngine;

public class BoidMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed =5f;
    public Vector3 Velocity {  get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 forwardXY = new Vector3(transform.right.x, transform.right.y, 0).normalized;
        Velocity = Vector2.Lerp(Velocity, forwardXY, Time.fixedDeltaTime);
        print(Velocity);
        this.transform.position += Velocity * moveSpeed * Time.fixedDeltaTime;
        
        LookRotation();
    }
    private void LookRotation()
    {
        //this.transform.rotation = Quaternion.Slerp(transform.localRotation, Quaternion.LookRotation(Velocity), Time.fixedDeltaTime);
        //if (Velocity.sqrMagnitude < 0.001f) return;

        //this.transform.localRotation = Quaternion.Euler(0, 180, 90);
    }
}
