﻿using JetBrains.Annotations;
using UnityEngine;

public abstract class SingletonMonoBehaviour<T> : Singleton where T : MonoBehaviour
{
    #region  Fields
    private static T _instance;

    private static readonly object Lock = new object();

    #endregion

    #region  Properties
    public static T Instance
    {
        get
        {
            if (Quitting)
            {
                return null;
            }
            lock (Lock)
            {
                if (_instance != null)
                    return _instance;
                var instances = FindObjectsOfType<T>();
                var count = instances.Length;
                if (count > 0)
                {
                    if (count == 1)
                        return _instance = instances[0];

                    for (var i = 1; i < instances.Length; i++)
                        Destroy(instances[i]);

                    return _instance = instances[0];
                }

                return _instance = new GameObject($"({nameof(Singleton)}){typeof(T)}")
                           .AddComponent<T>();
            }
        }
    }
    #endregion

    #region  Methods
    private void Awake()
    {
        OnAwake();
    }

    protected virtual void OnAwake() { }
    #endregion
}

public abstract class Singleton : MonoBehaviour
{
    #region  Properties
    public static bool Quitting { get; private set; }
    #endregion

    #region  Methods
    private void OnApplicationQuit()
    {
        Quitting = true;
    }
    #endregion
}