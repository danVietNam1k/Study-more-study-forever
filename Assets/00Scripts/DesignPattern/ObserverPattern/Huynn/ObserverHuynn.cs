using System;
using System.Collections.Generic;
using UnityEngine;

public class ObserverHuynn : MonoBehaviour
{
    static Dictionary<string, List<Action>> Listeners = new Dictionary<string, List<Action>>();
    public static void AddObserver(string name, Action callback)
    {
        if (!Listeners.ContainsKey(name))
            Listeners.Add(name, new List<Action>());

        Listeners[name].Add(callback);
    }

    public static void RemoveObserver(string name, Action callback)
    {
        if (!Listeners.ContainsKey(name)) return;

        Listeners[name].Remove(callback);
    }
    public static void Notify(string name)
    {
        if (!Listeners.ContainsKey(name)) return;

        foreach (var listener in Listeners[name])
        {
            try { listener.Invoke(); }
            catch (Exception e)
            {
                Debug.LogError("Error on Invoke: " + e);
            }
        }

    }
}
