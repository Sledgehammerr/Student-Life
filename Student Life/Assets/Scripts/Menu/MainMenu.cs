using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject login;

    public TMP_InputField inputUserName;

    private Player player;

    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Application.targetFrameRate = 60;
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void PlayButton()
    {
        menu.SetActive(false);

        new LoadManager();

        try
        {
            LoadManager.LoadInstance.LoadObject(Game.CurrentPlayer);
            SceneManager.LoadScene(1);
        }
        catch
        { 
        }
        login.SetActive(true);
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
            new SaveManager();
            SaveManager.Instance.SaveObject(Game.CurrentPlayer);
            SceneManager.LoadScene(1);
            
        }
    }
}
