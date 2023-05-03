using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T _instance;

    public static T Instance => _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = (T) this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
        DontDestroyOnLoad(this);
    }

    public bool IsInitialiezd()
    {
        return _instance != null;
    }
    
}
