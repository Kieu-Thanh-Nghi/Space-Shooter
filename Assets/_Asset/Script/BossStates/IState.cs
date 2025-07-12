using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void EnterState();
    StateIndex TheNextState();
    void UpdateState();
    void ExitState();
}
