using System;
using UnityEngine;

public class Observer : MonoBehaviour
{
    [SerializeField] private Subject subjectToObserver;
    private void OnThingHappen()
    {
        // any logic that responds to event goes here
        print("Observer responds");
    }
    private void OnEnable()
    {
        if(subjectToObserver != null)
        {
            subjectToObserver.ThingHappened += OnThingHappen;
        }
    }
    private void OnDisable()
    {
        if( subjectToObserver != null)
        {
            subjectToObserver.ThingHappened -= OnThingHappen;
        }
    }
    private void OnDestroy()
    {
        if (subjectToObserver != null)
        {
            subjectToObserver.ThingHappened -= OnThingHappen;
        }
    }
}
