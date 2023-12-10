using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventNotifierBase : ScriptableObject
{
    private List<IEventListener> listeners = new();

    public void Raise()
    {
        for(int i = listeners.Count -1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(IEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(IEventListener listener)
    {
        listeners.Remove(listener);
    }
}

public abstract class EventNotifierBase<TType> : EventNotifierBase
{
    private List<IEventListener<TType>> typedListeners = new();

    public void Raise(TType value)
    {
        for (int i = typedListeners.Count - 1; i >= 0; i--)
        {
            typedListeners[i].OnEventRaised(value);
        }
    }

    public void RegisterListener(IEventListener<TType> listener)
    {
        typedListeners.Add(listener);
    }

    public void UnregisterListener(IEventListener<TType> listener)
    {
        typedListeners.Remove(listener);
    }
}
