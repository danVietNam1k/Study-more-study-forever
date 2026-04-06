using System;
using System.Collections.Generic;
using UnityEngine;

public class Listener : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ObserverHuynn.Notify("upDateUI");
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ObserverHuynn.AddObserver("upDateUI", OnUpdateUI);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ObserverHuynn.RemoveObserver("upDateUI", OnUpdateUI);

        }

    }
    private void Start()
    {
        //ObserverHuynn.AddObserver("upDateUI", OnUpdateUI);
    }
    private void OnDestroy()
    {
        //ObserverHuynn.RemoveObserver("upDateUI", OnUpdateUI);
    }
    void OnUpdateUI()
    {
        Debug.Log("UI Update");
    }
}
