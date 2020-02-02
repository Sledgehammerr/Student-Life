using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;


public interface ILoadManager
{    
    void Load(string key, out string value);
    void Load(string key, out int value);
    void Load(string key, out float value);
    void LoadObject(ILoadableObject obj);
}

public interface ILoadableObject
{
    void Load(ILoadManager man);
}

public class LoadManager : ILoadManager
{
    public event EventHandler<ILoadableObject> ObjectDidLoad;
    //public event EventHandler<ILoadableObject> DidStartLoad;
    //public event EventHandler<ILoadableObject> DidEndLoad;
    
    public static LoadManager LoadInstance { get; private set; }
    static LoadLogger LoggerInstance;

    public LoadManager()
    {
        if(LoadInstance == null)
        {
            LoadInstance = this;
            LoggerInstance = new LoadLogger(LoadInstance);
        }
    }

    public void Load(string key, out string value)
    {
        value = PlayerPrefs.GetString(key);
    }

    public void Load(string key, out int value)
    {
        value = PlayerPrefs.GetInt(key);
    }

    public void Load(string key, out float value)
    {
        value = PlayerPrefs.GetFloat(key);
    }

    public void LoadObject(ILoadableObject obj)
    {
        ObjectDidLoad(this, obj);
        obj.Load(this);
        
    }
}