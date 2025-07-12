using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class State1 : MonoBehaviour, IState
{
    [SerializeField] GameObject Boss;
    [SerializeField] FlyPath path;
    [SerializeField] float stateTime;
    [SerializeField] float speed;
    EnemyMove enemyMove;
    float timeEnter;

    public void EnterState()
    {
        timeEnter = Time.time;
        enemyMove = Boss.GetComponent<EnemyMove>();
        enemyMove.flyPath = path;
        enemyMove.flySpeed = speed;
    }

    public void ExitState()
    {
        
    }

    public IState TheNextState()
    {
        if(Time.time - timeEnter > stateTime)
        {
            return GetComponent<State2>();
        }
        return null;
    }

    public void UpdateState()
    {
        enemyMove.Move();
    }

    StateIndex IState.TheNextState()
    {
        throw new NotImplementedException();
    }
}
