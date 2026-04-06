using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class DelegateHuynn : MonoBehaviour
{
    int i = 1;
    delegate void DelegateFuntion();
    DelegateFuntion theFuntion;
    delegate int DelegateNumber(int num);
    DelegateNumber theNumber;
    Func<int> c;
    Action f;
    Action<int> f1;
    public UnityEvent unityEvent;
    public UnityAction unityAction;
    void DoSomething()
    {
        print(i);
        i++;
    }
    void DoSomething2()
    {
        print(i);
        i++;
    }
    int CheckVar(int num)
    {
     
        return num;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        theFuntion += DoSomething;
        theFuntion += DoSomething2;
        theNumber = CheckVar;

    }
    Coroutine crt;
    // Update is called once per frame
    void Update()
    {

        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            theFuntion?.Invoke();
        }
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            crt = StartCoroutine(WaitByIEnum());

        }
        if (Keyboard.current.cKey.wasPressedThisFrame) StopCoroutine(crt);

    }
    IEnumerator WaitByIEnum()
    {
        
        yield return new WaitForSeconds(2f);
        print("corotin is done");
    }
}
