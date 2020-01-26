using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI textUserName;
    public TextMeshProUGUI textMoney;
    public GameObject barHealth;
    public GameObject barSatiety;
    public GameObject barStamina;
    public TextMeshProUGUI textStudyCount;
    public TextMeshProUGUI textStudyTimeReq;
    public WorkController workController;
    public TextMeshProUGUI textDate;
    public TextMeshProUGUI textPart;

    public MessageController messageController;
    public GameObject EndGame;

    void Start()
    {
        Game.CurrentUIController = this;
        
        
        SaveLoadManager.LoadGame();
        UpdateUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SaveLoadManager.SaveGame();
            SceneManager.LoadScene(0);
        }
    }

    public void UpdateUI()
    {
        textUserName.text = Game.CurrentPlayer.UserName;
        textMoney.text = Game.CurrentPlayer.Money.ToString();
        barHealth.GetComponent<Image>().fillAmount = (float)Game.CurrentPlayer.Health / 100;
        barSatiety.GetComponent<Image>().fillAmount = (float)Game.CurrentPlayer.Satiety / 100;
        barStamina.GetComponent<Image>().fillAmount = (float)Game.CurrentPlayer.Stamina / 100;
        textDate.text = Game.CurrentPlayer.Date.Day + "." + Game.CurrentPlayer.Date.Month + "." + Game.CurrentPlayer.Date.Year;
        textPart.text = Game.CurrentPlayer.PartsDay + "/3";

        if (Game.CurrentPlayer.currentHomeWork != null)
        {
            textStudyCount.text = Game.CurrentPlayer.currentHomeWork.CompletionTime.ToString();
            textStudyTimeReq.text = Game.CurrentPlayer.currentHomeWork.CompletionRequirement.ToString();
        }

        if (Game.CurrentPlayer.currentWork != null)
        {
            workController.UpdateUI();
        }
    }
}
