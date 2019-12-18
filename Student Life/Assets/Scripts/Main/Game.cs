using System;
using UnityEngine;

public static class Game
{
    public static Player CurrentPlayer = Player.playerInstance;
    public static UIController CurrentUIController;
    public static GameMenu CurrentGameMenu;


    public static void ChangeStat(int money, int health, int satiety, int stamina)
    {
        CurrentPlayer.Money += money;
        CurrentPlayer.Health += health;
        CurrentPlayer.Satiety += satiety;
        CurrentPlayer.Stamina += stamina;
        CurrentUIController.UpdateUI();
    }

    //public static void GenerateTask(Task task)
    //{
    //    if (task is HomeWork)
    //    {
    //        HomeWork homeWork = task as HomeWork;
    //        homeWork.Name = "Домашняя работа";
    //        homeWork.CompletionTime = 4;
    //        homeWork.CompletionRequirement = 7;
    //        CurrentPlayer.currentHomeWork = homeWork;
    //    }
    //    //if (task is Work)
    //    //{
    //    //    System.Random random = new System.Random();
    //    //}
    //}

    public static void DoTask(Task task)
    {
        ChangeStat(0, 0, -10, -10);
        task.CompletionTime--;
        TimeIncrease();
        
        
    }

    public static void TimeIncrease()
    {
        CurrentPlayer.PartsDay++;
        if (CurrentPlayer.Health <= 0)
        {
            CurrentUIController.EndGame.SetActive(true);
        }

        if (CurrentPlayer.currentHomeWork != null)
        {


            if (CurrentPlayer.currentHomeWork.CompletionRequirement != 0)
            {
                CurrentPlayer.currentHomeWork.CompletionRequirement--;
            }

            if (CurrentPlayer.currentHomeWork.CompletionTime == 0)
            {
                CurrentPlayer.currentHomeWork.CompleteTask();
                Debug.Log("Grade: " + CurrentPlayer.Grade);
                CurrentGameMenu.StudyPanel.SetActive(false);
            }
            else if (CurrentPlayer.currentHomeWork.CompletionRequirement == 0)
            {
                CurrentPlayer.currentHomeWork.FailTask();
                Debug.Log("Grade: " + CurrentPlayer.Grade);
                CurrentGameMenu.StudyPanel.SetActive(false);
            }


        }

        if ((CurrentPlayer.Date.Day % 7) == 0)
        {
            if (CurrentPlayer.PartsDay == 1)
            {
                if (CurrentPlayer.currentHomeWork == null)
                {
                    Debug.Log("Task");
                    CurrentPlayer.currentHomeWork = ScriptableObject.CreateInstance<HomeWork>();
                    CurrentPlayer.currentHomeWork.Init();
                }
                Debug.Log("Save");
                SaveLoadManager.SaveGame();
            }
        }

        CurrentUIController.UpdateUI();
    }
}
