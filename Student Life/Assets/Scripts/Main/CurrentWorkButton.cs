using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentWorkButton : Button
{
    public Work CurrentWork;
    public void Awake()
    {
        onClick.AddListener(ButtonClicked);
    }

    public void ButtonClicked()
    {
        Game.DoTask(CurrentWork);
    }
}