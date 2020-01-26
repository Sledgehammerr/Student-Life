using UnityEngine;
using TMPro;

public class WorkPanel : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public TextMeshProUGUI Count;
    public TextMeshProUGUI Req;
    public TextMeshProUGUI Money;

    public WorkAcceptButton Button;

    public void Init()
    {
        Button.CurrentWork = ScriptableObject.CreateInstance<Work>();
        Button.CurrentWork.Init();
        Text.text = Button.CurrentWork.Name;
        Count.text = Button.CurrentWork.CompletionTime.ToString();
        Req.text = Button.CurrentWork.CompletionRequirement.ToString();
        Money.text = Button.CurrentWork.Reward.ToString();
    }

    public void Init(string Text, int Count, int Req, int Money)
    {
        this.Text.text = Button.CurrentWork.Name;
        this.Count.text = Button.CurrentWork.CompletionTime.ToString();
        this.Req.text = Button.CurrentWork.CompletionRequirement.ToString();
        this.Money.text = Button.CurrentWork.Reward.ToString();
    }

    void OnDestroy()
    {
        Destroy(Button.CurrentWork);
    }
}
