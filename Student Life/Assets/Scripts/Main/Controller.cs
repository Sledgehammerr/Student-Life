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

    private Player player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {
        textUserName.text = player.UserName;
        textMoney.text = player.Money.ToString();
        textHealth.text = player.Health.ToString();
        textSatiety.text = player.Satiety.ToString();
        textStamina.text = player.Stamina.ToString();
        textDate.text = player.Date.Day + "." + player.Date.Month + "." + player.Date.Year;
        textPart.text = player.PartsOfDay + "/3";

        if (player.Health == 0)
        {
            EndGame.SetActive(true);
        }
    }

    public void Message(string message)
    {
        //do something
    }

}
