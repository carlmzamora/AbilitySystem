using UnityEngine;

public abstract class Attribute : ScriptableObject { }

public class Attribute<T> : Attribute
{
    public T value;

    public static implicit operator T (Attribute<T> reference)
    {
        return reference.value;
    }
}

[CreateAssetMenu(menuName = "Attribute/float")]
public class Attribute_Float : Attribute<float> { }

[CreateAssetMenu(menuName = "Attribute/int")]
public class Attribute_Int : Attribute<int> { }