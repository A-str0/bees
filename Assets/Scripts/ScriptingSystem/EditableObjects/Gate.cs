using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour, IEditable
{
    public GateState state;

    private void Update() {
        
    }

    public void Edit() {

    }
    public void Run() {

    }

    public enum GateState {
        Opened,
        Changing,
        Closed
    }
}
