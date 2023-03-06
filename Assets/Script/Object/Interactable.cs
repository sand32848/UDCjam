using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [field: SerializeField] public UnityEvent LookEvent  { get; private set; } 
    [field: SerializeField] public UnityEvent InteractEvent { get; private set; }
}
