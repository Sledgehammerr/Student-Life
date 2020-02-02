using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeWork : Task//, ISavedObject, ILoadObject 
{//todo
    public override void Init()
    {
        CompletionTime = 4;
        CompletionRequirement = 7;
    }

    public override void CompleteTask()
    {
        Game.CurrentPlayer.Grade += 0.5f;
        Game.Message($"Домашняя работа выполнена. Ваш текущий балл - {Game.CurrentPlayer.Grade}");
        Destroy(this);
    }

    public override void FailTask()
    {
        Game.CurrentPlayer.Grade--;
        Game.Message($"Домашняя работа не выполнена. Ваш текущий балл - {Game.CurrentPlayer.Grade}");
        Destroy(this);
    }

    public void Save()
    {
        PlayerPrefs.SetInt("CompletionTime", CompletionTime);
        PlayerPrefs.SetInt("CompletionRequirement", CompletionRequirement);
    }

    public void Load()
    {
        CompletionTime = PlayerPrefs.GetInt("CompletionTime");
        CompletionRequirement = PlayerPrefs.GetInt("CompletionRequirement");
    }

    public bool TryLoad()
    {
        if (PlayerPrefs.HasKey("CompletionTime"))
        {
            Load();
            return true;
        }
        return false;
    }

}
