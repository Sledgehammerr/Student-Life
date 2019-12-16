using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI textUserName;
    public TextMeshProUGUI textMoney;
    public GameObject barHealth;
    public GameObject barSatiety;
    public GameObject barStamina;
    //public TextMeshProUGUI textHealth;
    //public TextMeshProUGUI textSatiety;
    //public TextMeshProUGUI textStamina;
    public TextMeshProUGUI textDate;
    public TextMeshProUGUI textPart;

    public GameObject EndGame;

    void Start()
    {
        Game.CurrentUIController = this;
        UpdateUI();
    }

    public void UpdateUI()
    {
        textUserName.text = Game.CurrentPlayer.UserName;
        textMoney.text = Game.CurrentPlayer.Money.ToString();
        barHealth.GetComponent<Image>().fillAmount = (float)Game.CurrentPlayer.Health / 100;
        barSatiety.GetComponent<Image>().fillAmount = (float)Game.CurrentPlayer.Satiety / 100;
        barStamina.GetComponent<Image>().fillAmount = (float)Game.CurrentPlayer.Stamina / 100;
        //textHealth.text = Game.CurrentPlayer.Health.ToString();
        //textSatiety.text = Game.CurrentPlayer.Satiety.ToString();
        //textStamina.text = Game.CurrentPlayer.Stamina.ToString();
        textDate.text = Game.CurrentPlayer.Date.Day + "." + Game.CurrentPlayer.Date.Month + "." + Game.CurrentPlayer.Date.Year;
        textPart.text = Game.CurrentPlayer.PartsDay + "/3";

        if (Game.CurrentPlayer.Health == 0)
        {
            EndGame.SetActive(true);
        }
    }

    public void Message(string message)
    {
        //do something
    }

}
