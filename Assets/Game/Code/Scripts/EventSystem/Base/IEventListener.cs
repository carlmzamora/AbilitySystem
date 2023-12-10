public interface IEventListener
{
    void OnEventRaised();
}

public interface IEventListener<TType>
{
    void OnEventRaised(TType value);
}
