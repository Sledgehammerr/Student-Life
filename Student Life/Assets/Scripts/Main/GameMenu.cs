using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject WorkListPanel;
    public GameObject WorkPanel;
    public GameObject ShopPanel;
    public GameObject StudyPanel;

    void Start()
    {
        Game.CurrentGameMenu = this;
    }

    public void SleepButton()
    {
        Game.ChangeStat(0, 20, -10, 50);
        Game.TimeIncrease();
    }

    public void StudyButton()
    {
        if (Game.CurrentPlayer.currentHomeWork != null)
        {
            if (StudyPanel.activeSelf)
            {
                StudyPanel.SetActive(false);
            }
            else
            {
                StudyPanel.SetActive(true);
                WorkListPanel.SetActive(false);
                WorkPanel.SetActive(false);
                ShopPanel.SetActive(false);
            }
        }
        else
        {
            Game.Message("У вас нет домашних заданий");
        }
    }

    public void WorkButton()
    {
        if (Game.CurrentPlayer.currentWork == null)
        {
            if (WorkListPanel.activeSelf)
            {
                WorkListPanel.SetActive(false);
            }
            else
            {
                StudyPanel.SetActive(false);
                WorkListPanel.SetActive(true);
                ShopPanel.SetActive(false);
            }
        }
        else
        {
            if (WorkPanel.activeSelf)
            {
                WorkPanel.SetActive(false);
            }
            else
            {
                StudyPanel.SetActive(false);
                WorkPanel.SetActive(true);
                ShopPanel.SetActive(false);
            }
        }
    }

    public void ShopButton()
    {
        if (ShopPanel.activeSelf)
        {
            ShopPanel.SetActive(false);
        }
        else
        {
            StudyPanel.SetActive(false);
            WorkListPanel.SetActive(false);
            WorkPanel.SetActive(false);
            ShopPanel.SetActive(true);
        }
    }

    public void EndGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
}
