using UnityEngine.UI;

public class StudyButton : Button
{
    public void Awake()
    {
        onClick.AddListener(ButtonClicked);
    }

    public void ButtonClicked() => Game.DoTask(Game.CurrentPlayer.currentHomeWork);
}
