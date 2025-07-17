using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateMachine : MonoBehaviour
{
    [SerializeField] State[] allStates;
    private State currentState;

    public void ChangeState(StateIndex newState)
    {
        currentState?.ExitState();
        currentState = allStates[(int)newState];
        currentState.EnterState(gameObject);
    }

    private void Start()
    {
        ChangeState(StateIndex.State0);
    }

    void Update()
    {
        if (currentState.TheNextState() != StateIndex.DontChange)
        {
            ChangeState(currentState.TheNextState());
        }
        currentState?.UpdateState();
    }
}
