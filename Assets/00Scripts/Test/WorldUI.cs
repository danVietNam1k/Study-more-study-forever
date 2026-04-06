using UnityEngine;
using DG.Tweening;
public class WorldUI : MonoBehaviour
{
   public void ClickBtn(RectTransform text) {

        text.gameObject.SetActive(true);

        text.anchoredPosition = Vector2.zero;
        text.DOAnchorPos3DY(1f, 1f).OnComplete(() =>
        {
            text.gameObject.SetActive(false);
        });
    
    }

}
