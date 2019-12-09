using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Player
{
    public static string UserName { get; set; }
    private static int money;
    private static int health;
    private static int satiety;
    private static int stamina;
    private static int partsDay;
    public static DateTime Date { get; set; }

    public static int Money
    {
        get { return money; }
        set
        {
            if (value < 0)
            {
                money = 0;
            }
            else
            {
                money = value;
            }
            
        }
    }

    public static int Health
    {
        get { return health; }
        set
        {
            if (value > 100)
            {
                health = 100;
            }
            else if (value < 0)
            {
                health = 0;
            }
            else
            {
                health = value;
            }
        }
    }

    public static int Satiety 
    {
        get { return satiety; }
        set
        {
            if (value > 100)
            {
                satiety = 100;
            }
            else if (value < 0)
            {
                satiety = 0;
                Health -= 34;
            }
            else
            {
                satiety = value;
            }
        }
    }

    public static int Stamina 
    {
        get { return stamina; }
        set
        {
            if (value > 100)
            {
                stamina = 100;
            }
            else if (value < 0)
            {
                stamina = 0;
                health -= 34;
            }
            else
            {
                stamina = value;
            }
        }
    }

    public static int PartsOfDay
    { 
        get { return partsDay; }
        set {
            if (partsDay >= 3)
            {
                Date = Date.AddDays(1);
                partsDay = 1;
            }
            else
            {
                partsDay = value;
            }
        }
    }

    public static void Init()
    {
        Date = DateTime.Now;
        
        money = 1000;
        health = 100;
        satiety = 100;
        stamina = 100;
        partsDay = 1;
    }
}