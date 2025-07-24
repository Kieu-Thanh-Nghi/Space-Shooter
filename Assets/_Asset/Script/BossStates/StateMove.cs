using UnityEngine;

[CreateAssetMenu(fileName = "StateMove", menuName = "My ScriptableObject/States")]
public class StateMove : State
{
    GameObject Boss;
    [SerializeField] FlyPath path;
    [SerializeField] float stateTime;
    [SerializeField] float speed;
    [SerializeField] StateIndex NextState;
    EnemyMove enemyMove;
    float timeEnter;

    public override void EnterState(GameObject boss)
    {
        Boss = boss;
        timeEnter = Time.time;
        enemyMove = Boss.GetComponent<EnemyMove>();
        enemyMove.flyPath = path;
        enemyMove.flySpeed = speed;
    }

    public override void ExitState()
    {

    }

    public override StateIndex TheNextState()
    {
        if (Time.time - timeEnter > stateTime)
        {
            return NextState;
        }
        return StateIndex.DontChange;
    }

    public override void UpdateState()
    {
        enemyMove.Move();
    }
}
