using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICondition
{
    public abstract event System.Action action;
}
