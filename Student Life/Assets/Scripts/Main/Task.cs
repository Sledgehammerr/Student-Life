using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Task : MonoBehaviour
{
    private static Random random = new Random();
    public int CompletionTime { get; set; }
    
}
