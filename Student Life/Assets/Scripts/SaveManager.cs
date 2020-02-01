using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public interface ISaveManager
{
    void SaveData(string key, string value);
    void SaveData(string key, int value);
    void SaveData(string key, float value);
    void SaveObject(ISavedObject obj);
}

public interface ISavedObject
{
    void Save(ISaveManager man);
}
class SaveManager : ISaveManager
{
    FileInfo file;

    public SaveManager()
    {
    }

    public SaveManager(string filename)
    {
        file = new FileInfo(filename);
    }

    public void SaveData(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }

    public void SaveData(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    public void SaveData(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    public void SaveObject(ISavedObject obj)
    {
        obj.Save(this);
    }
}