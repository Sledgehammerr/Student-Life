using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Work : Task
{
    public string Name;
    public static List<string> NameList { get; private set; } = new List<string>() { "Работа0", "Работа1", "Работа2", "Работа3", "Работа4" };

    private static System.Random random = new System.Random();
    public int Reward { get; private set; }

    public override void Init()
    {
        Name = NameList[random.Next(0, 4)];
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
        Destroy(this);
        Game.CurrentPlayer.currentWork = null;
    }

}
