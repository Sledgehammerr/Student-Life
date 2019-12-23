using System;
using System.Collections.Generic;
using UnityEngine;

public class WorkListController : MonoBehaviour
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
}
