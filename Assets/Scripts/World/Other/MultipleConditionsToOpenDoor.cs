using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MultipleConditionsToOpenDoor : MonoBehaviour
{
    public int count = 2;
    public UnityEvent action;

    int cur = 0;

    public void Add() {cur++; if (cur == count) action?.Invoke(); }
}
