using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "My ScriptableObject/DataEnemyWave")]
public class EnemyWave: ScriptableObject
{
    public Transform enemyPrefab;
    public int numberOfEnemy;
    public Vector3 formationOffset;
    public FlyPath flyPath;
    public float speed;
    public float nextWaveDelay;

    public void OnDrawGizmos()
    {
        if (flyPath.waypoints == null) return;

        Gizmos.color = Color.green;
        for (int i = 0; i < flyPath.waypoints.Length - 1; i++)
        {
            Gizmos.DrawLine(flyPath.waypoints[i].transform.position, flyPath.waypoints[i + 1].transform.position);
        }
    }
}

