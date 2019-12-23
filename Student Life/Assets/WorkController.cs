using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorkController : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI textWorkCount;
    public TextMeshProUGUI textWorkTimeReq;
    public TextMeshProUGUI Reward;
    public CurrentWorkButton Button;

    private Work currentWork;

    void Start()
    {
        currentWork = Game.CurrentPlayer.currentWork;
        //Button.CurrentWork = currentWork = Game.CurrentPlayer.currentWork;
        Button.CurrentWork = currentWork;
        Name.text = currentWork.Name;
        Reward.text = currentWork.Reward.ToString();
        UpdateUI();
    }

    // Update is called once per frame
    public void UpdateUI()
    {
        currentWork = Game.CurrentPlayer.currentWork;
        //Button.CurrentWork = currentWork = Game.CurrentPlayer.currentWork;
        Button.CurrentWork = currentWork;
        Name.text = currentWork.Name;
        Reward.text = currentWork.Reward.ToString();
        textWorkCount.text = currentWork.CompletionTime.ToString();
        textWorkTimeReq.text = currentWork.CompletionRequirement.ToString();
    }
}
