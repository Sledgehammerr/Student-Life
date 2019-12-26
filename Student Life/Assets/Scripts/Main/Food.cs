using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Food", menuName = "Food", order = 51)]

public class Food : Item
{
    [SerializeField] public int Health;
    [SerializeField] public int Satiety;
    [SerializeField] public int Stamina;
}
