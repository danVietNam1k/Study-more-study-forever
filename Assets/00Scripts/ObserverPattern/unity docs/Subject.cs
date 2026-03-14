using System;
using UnityEngine;

public class Subject : MonoBehaviour
{
    public event Action ThingHappened;
   
    public void DoThing()
    {
        ThingHappened?.Invoke();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(ThingHappened != null)  
            DoThing();
            else print("null");
        }
    }
}
