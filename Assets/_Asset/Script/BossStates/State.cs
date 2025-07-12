using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : ScriptableObject
{
    public abstract void EnterState(GameObject Boss);

    public abstract void ExitState();

    public abstract StateIndex TheNextState();

    public abstract void UpdateState();
}
