using UnityEngine;
using UnityEngine.InputSystem;

public class DragDropCtl : MonoBehaviour
{
    [SerializeField] public GameObject itemMoving;
    public static DragDropCtl Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame) {
            print(Input.mousePosition);
        } 
        if (itemMoving != null)
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPos.z = 0;
            itemMoving.transform.position = newPos;
        }

    }

}
