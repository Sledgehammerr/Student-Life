using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject login;

    public TMP_InputField inputUserName;

    public SaveLoadManager manager;

    private Player player;

    public void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void PlayButton()
    {
        menu.SetActive(false);
        if (manager.TryLoad())
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            login.SetActive(true);
        }
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }

    public void LoginButton()
    {
        if (inputUserName.text.Length > 3 && inputUserName.text.Length < 15)
        {

            player.UserName = inputUserName.text;
            player.Init();
            manager.SaveGame();
            SceneManager.LoadScene(1);
            
        }
        else
        {
            //TODO: message
        }
        

    }
}
