using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Variable<T> : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    
    private T value;
    
    public void SetValue(T v)
    {
        value = v;
    }

    public T Value
    {
        get { return value; }
    }
}