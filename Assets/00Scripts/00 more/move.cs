using UnityEngine;

public class move : MonoBehaviour
{
    public Vector3 _move;
    public float _speed;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
         _move = new Vector3 (Input.GetAxisRaw("Horizontal"),0f, Input.GetAxisRaw("Vertical"));

        rb.AddForce(_move, ForceMode.Force);
    }
}
