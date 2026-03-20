using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DOTweenUI : MonoBehaviour
{
    public Button playBTN;
    public Button settingsBTN;
    public Button exitBTN;
    public CanvasGroup canvasGroup;
    void Start()
    {
        playBTN.onClick.AddListener(PlayButtonAnim);
        settingsBTN.onClick.AddListener(SettingButtonAnim);
        exitBTN.onClick.AddListener(ExitButtonAnim);
        StartButtonAnim();

    }

    void PlayButtonAnim()
    {
        playBTN.transform.DOScale(1.2f, 0.2f).SetEase(Ease.OutBounce)
            .OnComplete(() => playBTN.transform.DOScale(1f, 0.2f));

    }
    void SettingButtonAnim()
    {
        settingsBTN.transform.DORotate(new Vector3(0, 0, 15f), 0.2f, RotateMode.Fast).SetLoops(2, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }
    void ExitButtonAnim()
    {
        exitBTN.transform.DOPunchScale(Vector3.one * 0.3f,0.3f,10,1f);
    }
    void StartButtonAnim()
    {
        canvasGroup.DOFade(1, 5f);
        RectTransform[] button=
        {
            playBTN.GetComponent<RectTransform>(),
            settingsBTN.GetComponent<RectTransform>(),
            exitBTN.GetComponent<RectTransform>(),
        };
        for (int i = 0; i < button.Length; i++) { 
        Vector2 targetPos = button[i].anchoredPosition;
            button[i].anchoredPosition = new Vector2(-500f, targetPos.y);
            button[i].DOAnchorPos(targetPos, 0.6f).SetEase(Ease.OutBack)
                .SetDelay(0.2f *i);
        }
    }

}
