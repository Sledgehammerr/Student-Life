using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FoodPanel : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Health;
    public TextMeshProUGUI Stamina;
    public TextMeshProUGUI Satiety;
    public TextMeshProUGUI Price;

    public StoreButton Button;

    private Food currentFood;

    public void Init()
    {
        currentFood = Button.CurrentItem as Food;

        Name.text = currentFood.Name;
        Health.text = currentFood.Health.ToString();
        Stamina.text = currentFood.Stamina.ToString();
        Satiety.text = currentFood.Satiety.ToString();
        Price.text = currentFood.Price.ToString();

    }
}
