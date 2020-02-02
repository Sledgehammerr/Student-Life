using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//interface ISavedObject
//{
//    void Save();
//}

//interface ILoadObject
//{
//    void Load();
//    bool TryLoad();
//}

public static class SaveLoadManager
{
    public static void SaveGame()
    {
        //Player.playerInstance.Save();


        //if (Game.CurrentPlayer.currentWork != null)
        //{
        //    Game.CurrentPlayer.currentWork.Save();
        //}

        //if (Game.ListController != null)
        //{
        //    Game.ListController.Save();
        //}

        //PlayerPrefs.Save();
    }
    
    public static void LoadGame()
    {
        //Player.playerInstance.Load();

        //Player.playerInstance.currentWork = new Work();
        //if(!Player.playerInstance.currentWork.TryLoad())
        //{
        //    Player.playerInstance.currentWork = null;
        //}
        
    }

    public static bool TryLoad()
    {
        if (PlayerPrefs.HasKey("Username"))
            return true;
        return false;
    }
}
