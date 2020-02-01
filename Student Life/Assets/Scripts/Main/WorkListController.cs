using System;
using System.Collections.Generic;
using UnityEngine;

public class WorkListController : MonoBehaviour//, ISavedObject, ILoadObject
{
    public GameObject WorkPrefab;
    public GameObject Content;
    public List<GameObject> ListWorkPrefab;
    public static WorkListController listController;
    private const int size = 5;

    private void Start()
    {
        listController = this;
        Game.ListController = this;
        Generate();

        TryLoad();
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
            WorkPanel workPanel = prefab.GetComponent<WorkPanel>();


            workPanel.Init();
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
        Debug.Log("SAVED");
        for (int i = 0; i < size; i++)
        {
            WorkPanel panel = ListWorkPrefab[i].GetComponent<WorkPanel>();
            PlayerPrefs.SetString("Work_Text_" + i, panel.Text.text);
            PlayerPrefs.SetInt("Work_Count_" + i, Convert.ToInt32(panel.Count.text));
            PlayerPrefs.SetInt("Work_Req_" + i, Convert.ToInt32(panel.Req.text));
            PlayerPrefs.SetInt("Work_Money_" + i, Convert.ToInt32(panel.Money.text));
        }
    }

    public void Load()
    {
        Debug.Log("LOADED");
        for (int i = 0; i < size; i++)
        {
            WorkAcceptButton button = ListWorkPrefab[i].GetComponentInChildren<WorkAcceptButton>();

            WorkPanel panel = ListWorkPrefab[i].GetComponent<WorkPanel>();

            button.CurrentWork.Init(
                PlayerPrefs.GetString("Work_Text_" + i),
                PlayerPrefs.GetInt("Work_Count_" + i),
                PlayerPrefs.GetInt("Work_Req_" + i),
                PlayerPrefs.GetInt("Work_Money_" + i));

            panel.Init(
                PlayerPrefs.GetString("Work_Text_" + i),
                PlayerPrefs.GetInt("Work_Count_" + i),
                PlayerPrefs.GetInt("Work_Req_" + i),
                PlayerPrefs.GetInt("Work_Money_" + i));

            Game.CurrentUIController.UpdateUI();
        }
    }

    public bool TryLoad()
    {
        if (PlayerPrefs.HasKey($"Work_Text_{0}"))
        {
            Load();
            return true;
        }
        return false;
    }
}
