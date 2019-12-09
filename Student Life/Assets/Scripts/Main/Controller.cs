using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Controller : MonoBehaviour
{
    public TextMeshProUGUI textUserName;
    public TextMeshProUGUI textMoney;
    public TextMeshProUGUI textHealth;
    public TextMeshProUGUI textSatiety;
    public TextMeshProUGUI textStamina;
    public TextMeshProUGUI textDate;
    public TextMeshProUGUI textPart;

    public GameObject EndGame;

    void Update()
    {
        textUserName.text = Player.UserName;
        textMoney.text = Player.Money.ToString();
        textHealth.text = Player.Health.ToString();
        textSatiety.text = Player.Satiety.ToString();
        textStamina.text = Player.Stamina.ToString();
        textDate.text = Player.Date.Day + "." + Player.Date.Month + "." + Player.Date.Year;
        textPart.text = Player.PartsOfDay + "/3";

        if (Player.Health == 0)
        {
            EndGame.SetActive(true);
        }
    }

}
