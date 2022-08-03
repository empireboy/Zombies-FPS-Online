using System;
using System.Collections.Generic;

public class ComponentContainer
{
    private Dictionary<Type, IActivatable> _components = new Dictionary<Type, IActivatable>();

    public void Add<T>(T component) where T : IActivatable
    {
        _components.Add(typeof(T), component);
    }

    public void Remove<T>() where T : IActivatable
    {
        _components.Remove(typeof(T));
    }

    public void SetActive<T>(bool active) where T : IActivatable
    {
        _components[typeof(T)].IsActive = active;
    }

    public void SetActiveAll(bool active)
    {
        foreach (KeyValuePair<Type, IActivatable> component in _components)
            component.Value.IsActive = active;
    }
}