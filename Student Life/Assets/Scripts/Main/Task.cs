using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Task : ScriptableObject
{
    [SerializeField] public string Name;
    [SerializeField] public int CompletionTime { get; set; }
    [SerializeField] public int CompletionRequirement { get; set; }
}
