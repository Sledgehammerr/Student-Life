using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkAcceptButton : Button
{
    public Work CurrentWork;
    public void Awake()
    {
        onClick.AddListener(ButtonClicked);
    }

    public void ButtonClicked()
    {
        Game.CurrentPlayer.currentWork = CurrentWork;
        Game.CurrentGameMenu.WorkListPanel.SetActive(false);
        Game.CurrentGameMenu.WorkPanel.SetActive(true);
        Game.CurrentUIController.UpdateUI();
    }
}