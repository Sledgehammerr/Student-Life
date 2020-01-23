﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Work : Task, SavedObject
{
    public string Name;
    public static List<string> NameList { get; private set; } = new List<string>() { "Продавец", "Оператор", "Сборщик", "Менеджер", "Фасовщик", "Водитель", "Грузчик", "Охранник" };

    private static System.Random random = new System.Random();
    public int Reward { get; private set; }

    public override void Init()
    {
        Name = NameList[random.Next(0, NameList.Count)];
        CompletionTime = random.Next(3, 8);
        CompletionRequirement = CompletionTime * 2;
        Reward = CompletionTime * 100;
    }

    public override void CompleteTask()
    {
        Game.CurrentPlayer.Money += Reward;
        Destroy(this);
        Game.CurrentPlayer.currentWork = null;
    }

    public override void FailTask()
    {
        Game.CurrentPlayer.Money -= Reward / 2;
        Game.Message($"Работа не выполнена, штраф {Reward / 2}");
        Destroy(this);
        Game.CurrentPlayer.currentWork = null;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("CompletionTime", CompletionTime);
        PlayerPrefs.SetInt("CompletionRequirement", CompletionRequirement);
    }
}
