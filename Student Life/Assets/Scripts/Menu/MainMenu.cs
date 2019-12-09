using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject login;

    public TMP_InputField inputUserName;

    public void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    public void PlayButton()
    {
        menu.SetActive(false);
        if (SaveLoadManager.TryLoad())
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
        if (inputUserName.text.Length > 3)
        {
            Player.UserName = inputUserName.text;
            Player.Init();
            SceneManager.LoadScene(1);
            SaveLoadManager.SaveGame();
            
            //if (SaveLoadManager.TryLoad())
            //{
            //    SaveLoadManager.LoadGame();
            //}
            //else
            //{
            //    Player.Init();
            //    SaveLoadManager.SaveGame();
            //}
            
            //SceneManager.LoadSceneAsync(1);
        }
        

    }
}
