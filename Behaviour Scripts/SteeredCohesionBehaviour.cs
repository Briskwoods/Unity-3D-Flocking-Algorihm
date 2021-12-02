using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/SteeredCohesion")]
public class SteeredCohesionBehaviour : FlockBehaviour
{
    Vector3 currentVelocity;

    public float agentSmoothTime = 0.5f;

    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        // If there are no neighbours, return no adjustments.
        if (context.Count == 0)
        {
            return Vector3.zero;
        }

        // Add all points together and average them out.
        Vector3 cohesiveMove = Vector2.zero;
        foreach (Transform item in context)
        {
            cohesiveMove += (Vector3)item.position;
        }

        cohesiveMove /= context.Count;

        // Create offset from agent position.
        cohesiveMove -= (Vector3)agent.transform.position;
        cohesiveMove = Vector3.SmoothDamp(agent.transform.forward, cohesiveMove, ref currentVelocity, agentSmoothTime);
        return cohesiveMove;
    }
}
