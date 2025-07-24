using UnityEngine;
using Dreamteck.Splines;

public class FlyPathAgent : MonoBehaviour
{
    public float flySpeed;
    public SplineComputer splineComputer;
    [SerializeField] SplineFollower splineFollower;

    

    private void Start()
    {           
        if(splineComputer != null) splineFollower.spline = splineComputer;
        splineFollower.followSpeed = flySpeed;
        splineFollower.onEndReached += OnEndPoint;
        splineFollower.enabled = false;
        //myCurve = flyPath.myCurve;
    }

    void OnEndPoint(double d)
    {
        EnemyHealth.LivingEnemyCount--;
        Destroy(gameObject);
    }

    public void EnableEnemy(float afterTime)
    {
        Invoke(nameof(EnableSplineFollower), afterTime);
    }

    void EnableSplineFollower()
    {
        splineFollower.enabled = true;
    }
}

