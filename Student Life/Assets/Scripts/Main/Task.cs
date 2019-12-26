using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Task : ScriptableObject
{
    [SerializeField] public int CompletionTime { get; set; }
    [SerializeField] public int CompletionRequirement { get; set; }

    public abstract void Init();
    public abstract void CompleteTask();
    public abstract void FailTask();
}