using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeWork : Task, SavedObject
{
    public override void Init()
    {
        CompletionTime = 4;
        CompletionRequirement = 7;
    }

    public override void CompleteTask()
    {
        Game.CurrentPlayer.Grade += 0.5;
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
        //todo 
        PlayerPrefs.SetInt("CompletionTime", CompletionTime);
        PlayerPrefs.SetInt("CompletionRequirement", CompletionRequirement);
    }
}
