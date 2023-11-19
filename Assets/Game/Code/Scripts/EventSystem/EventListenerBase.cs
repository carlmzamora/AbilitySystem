using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class EventListenerBase<TEvent, TResponse> : MonoBehaviour, IEventListener
    where TEvent : EventNotifierBase
    where TResponse : UnityEvent
{
    public TEvent Event;
    public TResponse Response;

    public void OnEventRaised()
    {
        Response.Invoke();
    }

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }
}

public abstract class EventListenerBase<TType, TEvent, TResponse> : MonoBehaviour, IEventListener<TType>
    where TEvent : EventNotifierBase<TType>
    where TResponse : UnityEvent<TType>
{
    public TEvent Event;
    public TResponse Response;

    public void OnEventRaised(TType value)
    {
        Response.Invoke(value);
    }

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }
}