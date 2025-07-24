using UnityEngine;
using Dreamteck.Splines;

[CreateAssetMenu(fileName = "Wave", menuName = "My ScriptableObject/DataEnemyWave")]
public class EnemyWave: ScriptableObject
{
    public Transform enemyPrefab;
    public int numberOfEnemy;
    public float timeOffset;
    public float speed;
    public float nextWaveDelay;
    public SplineComputer splineComputer;
}

