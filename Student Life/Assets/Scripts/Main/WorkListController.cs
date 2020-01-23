using System;
using System.Collections.Generic;
using UnityEngine;

public class WorkListController : MonoBehaviour, SavedObject
{
    public GameObject WorkPrefab;
    public GameObject Content;
    public List<GameObject> ListWorkPrefab;
    private const int size = 5;

    private void Start()
    {
        Game.ListController = this;
        Generate();
    }

    public void Generate()
    {
        if (ListWorkPrefab.Count != 0)
        {
            DeleteAll();
        }

        for (int i = 0; i < size; i++)
        {
            var prefab = Instantiate(WorkPrefab, Vector3.zero, Quaternion.identity);
            prefab.transform.SetParent(Content.transform, false);
            ListWorkPrefab.Add(prefab);
        }
    }

    private void DeleteAll()
    {
        for (int i = 0; i < size; i++)
        {
            Destroy(ListWorkPrefab[i]);
        }
        ListWorkPrefab.Clear();
        
        GC.Collect();
    }

    public void Save()
    {
        for (int i = 0; i < ListWorkPrefab.Count; i++)
        {
            WorkPanel panel = ListWorkPrefab[i].GetComponent<WorkPanel>();
            PlayerPrefs.SetString($"Work_Text_{i}", panel.Text.ToString());
            PlayerPrefs.SetInt($"Work_Count_{i}", Convert.ToInt32(panel.Count.ToString()));
            PlayerPrefs.SetInt($"Work_Req_{i}", Convert.ToInt32(panel.Req.ToString()));
            PlayerPrefs.SetInt($"Work_Money_{i}", Convert.ToInt32(panel.Money.ToString()));
        }
    }
}
