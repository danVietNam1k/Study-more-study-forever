using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class DOTweenCtlObj : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.aKey.isPressed)
        {
            MoveDotween();
        }
        if (Keyboard.current.sKey.isPressed)
        {
            MoveEasingsDotween();
        }
        if (Keyboard.current.dKey.isPressed)
        {
            SequenceDotween();
        }

    }

    void MoveDotween()
    {
        this.transform.DOMoveX(2f, 2f).OnComplete(() =>{

            this.transform.DOMoveY(2f, 2f);
            this.transform.DOMoveY(2f, 2f).SetDelay(2f);
        });
    }
    void MoveEasingsDotween()
    {
        this.transform.DOMoveX(2f,2f).SetEase(Ease.OutQuad); // easings.net
    }
    void ScaleDotween()
    {
        this.transform.DOScale(2f, 2f);
        this.transform.DOScale(1f, 2f).SetDelay(2f).SetEase(Ease.OutBounce);
    }
    void SequenceDotween()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(this.transform.DORotate(new Vector3(0, 180, 0), 1f))
            .Append(transform.DORotate(new Vector3(180, 180, 0), 1f))
            .Append(transform.DOScale(new Vector3(5, 5, 5), 1f));

        seq.SetDelay(3f).Append(transform.DOScale(new Vector3(2,2, 2), 1f))
            .Join(transform.GetComponent<Renderer>().material.DOColor(Color.green,5f));

    }
    void LoopDOTween()
    {
        transform.DOMove(Vector3.right,1f).SetLoops(1);
    }
    void PausePlayKill()
    {
        Tween tween = transform.DOMoveX(5f, 2f).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.OutSine);
       

        tween.Play();
        tween.Pause();
        tween.Kill();
    }
    
}
