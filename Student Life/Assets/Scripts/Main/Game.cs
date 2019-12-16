using System;
using UnityEngine;

public static class Game
{
    public static Player CurrentPlayer = Player.playerInstance;
    public static UIController CurrentUIController;
    //public static DateTime Date;
    //private static int partsDay;

    //public static int PartsDay
    //{
    //    get { return partsDay; }
    //    set
    //    {
    //        if (partsDay >= 3)
    //        {
    //            Date = Date.AddDays(1);
    //            partsDay = 1;
    //        }
    //        else
    //        {
    //            partsDay = value;
    //        }
    //    }
    //}

    public static void ChangeStat(int money, int health, int satiety, int stamina)
    {
        CurrentPlayer.Money += money;
        CurrentPlayer.Health += health;
        CurrentPlayer.Satiety += satiety;
        CurrentPlayer.Stamina += stamina;
        CurrentUIController.UpdateUI();
    }

    public static void TimeIncrease()
    {
        CurrentPlayer.PartsDay++;
        if (CurrentPlayer.Health <= 0)
        {
            CurrentUIController.EndGame.SetActive(true);
        }
        CurrentUIController.UpdateUI();
        if ((CurrentPlayer.Date.Day % 7) == 0)
        {
            if (CurrentPlayer.PartsDay == 1)
            {

            }
        }
    }
}
