using UnityEngine;
using TMPro;

public class WorkPanel : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public TextMeshProUGUI Count;
    public TextMeshProUGUI Req;
    public TextMeshProUGUI Money;

    public WorkAcceptButton Button;

    void Start()
    {
        Button.CurrentWork = ScriptableObject.CreateInstance<Work>();
        Button.CurrentWork.Init();
        Text.text = Button.CurrentWork.Name;
        Count.text = Button.CurrentWork.CompletionTime.ToString();
        Req.text = Button.CurrentWork.CompletionRequirement.ToString();
        Money.text = Button.CurrentWork.Reward.ToString();
    }

    void OnDestroy()
    {
        Destroy(Button.CurrentWork);
    }
}
