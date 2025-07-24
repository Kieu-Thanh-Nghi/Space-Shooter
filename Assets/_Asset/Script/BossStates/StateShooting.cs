using UnityEngine;

[CreateAssetMenu(fileName = "StateShootStraight", menuName = "My ScriptableObject/ShootStraightStates")]
public class StateShooting : State
{
    GameObject Boss;
    [SerializeField] FlyPath path;
    [SerializeField] float stateTime;
    [SerializeField] float speed;
    [SerializeField] StateIndex NextState;
    BossShootStraight bossShoot;
    EnemyMove enemyMove;
    float timeEnter;
    public override void EnterState(GameObject boss)
    {
        Boss = boss;
        timeEnter = Time.time;
        enemyMove = Boss.GetComponent<EnemyMove>();
        bossShoot = Boss.GetComponent<BossShootStraight>();
        enemyMove.flyPath = path;
        enemyMove.flySpeed = speed;
    }

    public override void ExitState()
    {
        bossShoot.enabled = false;
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
        enemyMove.Move(false);
        bossShoot.enabled = true;
    }
}
