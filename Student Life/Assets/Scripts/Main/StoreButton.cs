using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class StoreButton : Button
{
    public Item CurrentItem;
    public void Awake()
    {
        onClick.AddListener(ButtonClicked);
    }
    
    public void ButtonClicked() => Game.CurrentPlayer.Buy(CurrentItem);
}
