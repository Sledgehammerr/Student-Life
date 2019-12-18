using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject JobPanel;
    public GameObject ShopPanel;
    public GameObject StudyPanel;

    //private Player player;

    //void Start()
    //{
    //    player = GameObject.Find("Player").GetComponent<Player>();
    //}

    //void Update()
    //{
        
    //}

    public void SleepButton()
    {
        //player.ChangeStat(0, 20, -10, 50);
        //player.PartsOfDay++;
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
                JobPanel.SetActive(false);
                ShopPanel.SetActive(false);
            }
        }
        else
        {
            //Game.CurrentUIController.Message("У вас нет домашних заданий");
            Debug.Log("У вас нет домашних заданий");
        }
    }

    public void JobButton()
    {
        if (JobPanel.activeSelf)
        {
            JobPanel.SetActive(false);
        }
        else
        {
            StudyPanel.SetActive(false);
            JobPanel.SetActive(true);
            ShopPanel.SetActive(false);
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
            JobPanel.SetActive(false);
            ShopPanel.SetActive(true);
        }
    }

    public void EndGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }


}
