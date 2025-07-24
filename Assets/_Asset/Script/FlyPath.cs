using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPath : MonoBehaviour
{
    public Waypoint[] waypoints;
    public AnimationCurve myCurve;
    [SerializeField] int v;

    public Vector3 this[int index] => waypoints[index].transform.position;

    private void Reset() {
        waypoints = GetComponentsInChildren<Waypoint>();
        int endIndex = waypoints.Length - 1;
        myCurve = AnimationCurve.EaseInOut(this[0].x, this[0].y, this[endIndex].x, this[endIndex].y);
        for (int i = 0; i <= endIndex; i++)
        {
            myCurve.AddKey(this[i].x, this[i].y);
            myCurve.SmoothTangents(i, 0);
        }        
        
        for (int i = 0; i <= endIndex; i++)
        {
            Keyframe k = myCurve[i];                  
            k.weightedMode = WeightedMode.Both;
            myCurve.MoveKey(i, k);
        }
        
    }

    private void OnDrawGizmos()
    {
        if (waypoints == null) return;

        Gizmos.color = Color.green;
        for (int i = 0; i < waypoints.Length - 1; i++)
        {
            Gizmos.DrawLine(waypoints[i].transform.position, waypoints[i + 1].transform.position);
        }
    }
}
