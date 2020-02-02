using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ISavedObject, ILoadableObject
{//todo
    private string userName;
    private int money;
    private int health;
    private int satiety;
    private int stamina;
    private int partsDay;
    public HomeWork currentHomeWork;
    public Work currentWork;
    public DateTime Date { get; set; }
    private float grade;
    public static Player playerInstance { get; set; }

    public string UserName 
    {
        get { return userName; }
        set { userName = value; }
    }

    public int Money
    {
        get { return money; }
        set { money = value; }
    }

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

    public float Grade 
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
        grade = 5.0f;
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

    public void Save(ISaveManager man)
    {
        man.SaveData("Username", userName);
        man.SaveData("Money", money);
        man.SaveData("Health", health);
        man.SaveData("Satiety", satiety);
        man.SaveData("Stamina", stamina);
        man.SaveData("Day", Date.Day);
        man.SaveData("Month", Date.Month);
        man.SaveData("Year", Date.Year);
        man.SaveData("PartOfDay", partsDay);
        man.SaveData("Grade", (float)grade);
        Debug.Log("Save");
    }

    public void Init(ILoadManager man)
    {
        int day, month, year;
        man.Load("Username", out userName);
        man.Load("Money", out money);
        man.Load("Health", out health);
        man.Load("Satiety", out satiety);
        man.Load("Stamina", out stamina);
        man.Load("Day", out day);
        man.Load("Month", out month);
        man.Load("Year", out year);

        Date = new DateTime(year, month, day);

        man.Load("PartOfDay", out partsDay);
        man.Load("Grade", out grade);
    }

    public void Load(ILoadManager man)
    {
        int day, month, year;
        man.Load("Username", out userName);
        man.Load("Money", out money);
        man.Load("Health", out health);
        man.Load("Satiety", out satiety);
        man.Load("Stamina", out stamina);
        man.Load("Day", out day);
        man.Load("Month", out month);
        man.Load("Year", out year);

        Date = new DateTime(year, month, day);

        man.Load("PartOfDay", out partsDay);
        man.Load("Grade", out grade);

        Debug.Log("Load");
    }

    //public void Save()
    //{
    //    PlayerPrefs.SetString("Username", playerInstance.UserName);
    //    PlayerPrefs.SetInt("Money", playerInstance.Money);
    //    PlayerPrefs.SetInt("Health", playerInstance.Health);
    //    PlayerPrefs.SetInt("Satiety", playerInstance.Satiety);
    //    PlayerPrefs.SetInt("Stamina", playerInstance.Stamina);
    //    PlayerPrefs.SetInt("Day", playerInstance.Date.Day);
    //    PlayerPrefs.SetInt("Month", playerInstance.Date.Month);
    //    PlayerPrefs.SetInt("Year", playerInstance.Date.Year);
    //    PlayerPrefs.SetInt("PartOfDay", playerInstance.PartsDay);
    //    PlayerPrefs.SetFloat("Grade", (float)playerInstance.Grade);
    //}

    //public void Load()
    //{
    //    playerInstance.UserName = PlayerPrefs.GetString("Username");
    //    playerInstance.Money = PlayerPrefs.GetInt("Money");
    //    playerInstance.Health = PlayerPrefs.GetInt("Health");
    //    playerInstance.Satiety = PlayerPrefs.GetInt("Satiety");
    //    playerInstance.Stamina = PlayerPrefs.GetInt("Stamina");
    //    playerInstance.Date = new DateTime(PlayerPrefs.GetInt("Year"), PlayerPrefs.GetInt("Month"), PlayerPrefs.GetInt("Day"));
    //    playerInstance.PartsDay = PlayerPrefs.GetInt("PartOfDay");
    //    playerInstance.Grade = PlayerPrefs.GetFloat("Grade");
    //}

    //public bool TryLoad()
    //{
    //    if (PlayerPrefs.HasKey("Username"))
    //    {
    //        Load();
    //        return true;
    //    }
    //    return false;
    //}
}