using UnityEngine;

public class MoveByJoystick : MonoBehaviour
{
    Rigidbody rb;
    public Transform cameraView;
    public FixedJoystick fixedJoystick;
    public DynamicJoystick dynamicJoystick;
    public FloatingJoystick floatingJoystick;
    public VariableJoystick variableJoystick;
    public enum typeJoystick { fixedJoystick, dynamicJoystick, floatingJoystick, variableJoystick }
    public typeJoystick type;
    public float speed = 1f;
    [SerializeField] private float sensitivity = 0.15f;
    [SerializeField] private float maxAngle = 80f;

    private float xRotation = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
  
}

    // Update is called once per frame
    void Update()
    {
        LookAround();
    }
    private void FixedUpdate()
    {
        switch (type)
        {
            case typeJoystick.variableJoystick:
                VariableJoy();
                break;
            case typeJoystick.fixedJoystick:
                FixedJoy();
                break;
            case typeJoystick.dynamicJoystick: DynamicJoy(); break;
            case typeJoystick.floatingJoystick: FloatingJoy(); break;
        }

    }
    void LookAround()
    {
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);

        // ❌ Nếu ở bên trái → bỏ qua (dành cho joystick)
        if (touch.position.x < Screen.width / 2) return;

        if (touch.phase == TouchPhase.Moved)
        {
            Vector2 delta = touch.deltaPosition;

            float mouseX = delta.x * sensitivity;
            float mouseY = delta.y * sensitivity;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -maxAngle, maxAngle);

            cameraView.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            this.transform.Rotate(Vector3.up * mouseX);
        }
    }
    private void OnValidate()
    {
        SetJoystick();
    }
    void SetJoystick()
    {
        fixedJoystick.gameObject.SetActive(false);
        floatingJoystick.gameObject.SetActive(false);
        variableJoystick.gameObject.SetActive(false);
        dynamicJoystick.gameObject.SetActive(false);
        switch (type)
        {
            case typeJoystick.variableJoystick:
                variableJoystick.gameObject.SetActive(true);

                break;
            case typeJoystick.fixedJoystick:
                fixedJoystick.gameObject.SetActive(true);
                break;
            case typeJoystick.dynamicJoystick:
                dynamicJoystick.gameObject.SetActive(true);
                break;
            case typeJoystick.floatingJoystick:
                floatingJoystick.gameObject.SetActive(true);

                break;
        }
    }
    void FixedJoy()
    {
        float X = fixedJoystick.Horizontal * speed ;
        float Z = fixedJoystick.Vertical * speed;
        Vector3 direct = this.transform.forward * Z + this.transform.right * X;
        rb.AddForce(direct, ForceMode.Force);
    }
    void DynamicJoy()
    {
        float X = dynamicJoystick.Horizontal * speed;
        float Z = dynamicJoystick.Vertical * speed;
        Vector3 direct = this.transform.forward * Z + this.transform.right * X;
        rb.AddForce(direct, ForceMode.Force);
    }
    void FloatingJoy()
    {
        float X = floatingJoystick.Horizontal * speed;
        float Z = floatingJoystick.Vertical * speed;
        Vector3 direct = this.transform.forward * Z + this.transform.right * X;
        rb.AddForce(direct, ForceMode.Force);
    }
    void VariableJoy()
    {
        float X = variableJoystick.Horizontal * speed;
        float Z = variableJoystick.Vertical * speed;
        Vector3 direct = this.transform.forward * Z + this.transform.right * X;
        rb.AddForce(direct, ForceMode.Force);
    }
    public void Typejoystick(int index)
    {
        switch (index)
        {
            case 0:
                type = typeJoystick.fixedJoystick;
                break;
            case 1:
                type = typeJoystick.dynamicJoystick;

                break;
            case 2:
                type = typeJoystick.floatingJoystick;

                break;
            case 3:
                type = typeJoystick.variableJoystick;

                break;

        }
        SetJoystick();
    }
}
