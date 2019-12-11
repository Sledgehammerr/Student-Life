using UnityEngine;

public class Shop_Supermarket : MonoBehaviour
{
    private Player player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void NoodlesButton()
    {
        player.ChangeStat(-30, -5, 15, 5);
    }

    public void AppleButton()
    {
        player.ChangeStat(-30, 10, 5, 5);
    }

    public void LunchButton()
    {
        player.ChangeStat(-100, 5, 10, 40);
    }
}
