using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Work : Task//, ISavedObject, ILoadObject
{//todo
    public string Name;
    public static List<string> NameList { get; private set; } = new List<string>() { "Продавец", "Оператор", "Сборщик", "Менеджер", "Фасовщик", "Водитель", "Грузчик", "Охранник" };

    private static System.Random random = new System.Random();
    public int Reward { get; private set; }

    private SaveManager saveManager;

    public override void Init()
    {
        Name = NameList[random.Next(0, NameList.Count)];
        CompletionTime = random.Next(3, 8);
        CompletionRequirement = CompletionTime * 2;
        Reward = CompletionTime * 100;
    }

    public void Init(string Name, int CompletionTime, int CompletionRequirement, int Reward)
    {
        this.Name = Name;
        this.CompletionTime = CompletionTime;
        this.CompletionRequirement = CompletionRequirement;
        this.Reward = Reward;
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
        PlayerPrefs.SetInt("Work_CompletionTime", CompletionTime);
        PlayerPrefs.SetInt("Work_CompletionRequirement", CompletionRequirement);
        PlayerPrefs.SetInt("Work_Reward", Reward);
    }

    public void Load()
    {
        CompletionTime = PlayerPrefs.GetInt("Work_CompletionTime");
        CompletionRequirement = PlayerPrefs.GetInt("Work_CompletionRequirement");
        Reward = PlayerPrefs.GetInt("Work_Reward");
    }

    public bool TryLoad()
    {
        if(PlayerPrefs.HasKey("CompletionTime"))
        {
            Load();
            return true;
        }
        return false;
    }
}
