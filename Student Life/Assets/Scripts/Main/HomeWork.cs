using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "new HomeWork", menuName = "HomeWork", order = 52)]
public class HomeWork : Task
{
    public override void Init()
    {
        //Name = "Домашняя работа";
        CompletionTime = 4;
        CompletionRequirement = 7;
    }

    public override void CompleteTask()
    {
        Debug.Log("Homework complete");
        Game.CurrentPlayer.Grade += 0.5;
        Destroy(this);
    }

    public override void FailTask()
    {
        Debug.Log("Homework failed");
        Game.CurrentPlayer.Grade--;
        Destroy(this);
    }


    //public HomeWork Generate()
    //{
    //    HomeWork.CreateInstance(
    //    return result;
    //}
}
