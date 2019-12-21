using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkListController : MonoBehaviour
{
    public GameObject WorkPrefab;
    public GameObject Content;
    public List<GameObject> ListWorkPrefab;
    private const int size = 20;

    private void Start()
    {
        Generate();
    }

    public void Generate()
    {
        for (int i = 0; i < size; i++)
        {
            //var prefab = Instantiate(WorkPrefab, new Vector3(0, 60 * i, 1), Quaternion.identity);
            //prefab.transform.parent = Content.transform;

            var prefab = Instantiate(WorkPrefab, Vector3.zero, Quaternion.identity);
            prefab.transform.SetParent(Content.transform, false);
            prefab.transform.localPosition = new Vector3(0, Content.transform.localPosition.y - 90 * i, 0);
            
            //prefab.transform.localScale = Vector3.one;
            ListWorkPrefab.Add(prefab);
            
        }
    }
}
