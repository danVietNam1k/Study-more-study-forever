using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private void OnMouseDown()
    {
        print("moust down");
        DragDropCtl.Instance.itemMoving = this.gameObject;
    }
    private void OnMouseUp()
    {
        print("moust up");
        DragDropCtl.Instance.itemMoving = null;

    }
  
}
