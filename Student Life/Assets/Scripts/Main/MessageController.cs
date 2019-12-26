using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageController : MonoBehaviour
{
    public GameObject Panel;
    public TextMeshProUGUI Text;

    public void Message(string text)
    {
        Panel.SetActive(true);
        Text.text = text;
    }

    public void Close()
    {
        Panel.SetActive(false);
    }

}
