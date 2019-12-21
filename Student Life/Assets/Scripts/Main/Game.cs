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

        if ((CurrentPlayer.Date.Day % 7) == 0 && CurrentPlayer.PartsDay == 1)
        {
            if (CurrentPlayer.currentHomeWork == null)
            {
                Debug.Log("Homework");
                CurrentPlayer.currentHomeWork = ScriptableObject.CreateInstance<HomeWork>();
                CurrentPlayer.currentHomeWork.Init();
            }
            Debug.Log("Save");
            SaveLoadManager.SaveGame();
        }

        if (CurrentPlayer.Date.Day == 1 && CurrentPlayer.PartsDay == 1 && CurrentPlayer.Grade >= 4f)
        {
            Debug.Log("Money");
            ChangeStat(500 * (int)(CurrentPlayer.Grade - 3.0), 0, 0, 0);
        }

        CurrentUIController.UpdateUI();
    }
}
