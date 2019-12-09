using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void HomeMenu()
    {

    }

    public void StudyMenu()
    {

    }

    public void JobMenu()
    {

    }

    public void WorkMenu()
    {

    }

    public void EndGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }

    public void Eat()
    {
        Player.Money -= 30;
        Player.Health -= 5;
        Player.Satiety += 15;
        Player.Stamina += 5;

        Player.PartsOfDay++;
        
    }
    public void Sleep()
    {
        Player.Stamina += 50;
        Player.Health += 20;
        Player.Satiety -= 10;

        Player.PartsOfDay++;
    }
}
