using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string UserName { get; set; }
    public int Money { get; set; }
    private int health;
    private int satiety;
    private int stamina;
    private int partsDay;
    public HomeWork currentHomeWork;
    public DateTime Date { get; set; }
    private double grade;
    public static Player playerInstance { get; set; }

    public int Health
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

    public int Satiety 
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

    public int Stamina 
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

    public int PartsDay
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

    public double Grade 
    {
        get { return grade; }
        set
        {
            if (value > 5)
            {
                grade = 5;
            }
            else if (value < 2)
            {
                grade = 2;
            }
            else
            {
                grade = value;
            }
        }
    }

    
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (playerInstance == null)
        {
            playerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Init()
    {
        Date = DateTime.Now;
        
        Money = 1000;
        Health = 100;
        Satiety = 100;
        Stamina = 100;
        PartsDay = 1;
        grade = 5.0;
    }

    public void Buy(Item item)
    {
        if (Money - item.Price >= 0)
        {
            if (item is Food)
            {
                Food food = item as Food;
                Game.ChangeStat(-food.Price, food.Health, food.Satiety, food.Stamina);
            }
        }
    }
}