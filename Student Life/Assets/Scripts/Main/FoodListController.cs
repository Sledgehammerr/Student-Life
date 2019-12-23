using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodListController : MonoBehaviour
{
    public string Name;
    public GameObject FoodPrefab;
    public GameObject Content;
    public List<Item> ItemList;

    void Start()
    {
        for (int i = 0; i < ItemList.Count; i++)
        {
            var prefab = Instantiate(FoodPrefab, Vector3.zero, Quaternion.identity);
            
            FoodPanel foodPanel = prefab.GetComponent<FoodPanel>();
            foodPanel.Button.CurrentItem = ItemList[i];
            foodPanel.Init();
            prefab.transform.SetParent(Content.transform, false);
            
        }
    }

}
