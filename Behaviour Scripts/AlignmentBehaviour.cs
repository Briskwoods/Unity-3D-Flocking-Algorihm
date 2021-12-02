using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Alignment")]
public class AlignmentBehaviour : FlockBehaviour
{
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        // If there are no neighbours, Maintain current alignment.
        if (context.Count == 0)
        {
            return agent.transform.up;
        }

        // Add all points together and average them out.
        Vector3 alignmentMove = Vector3.zero;
        foreach (Transform item in context)
        {
            alignmentMove += (Vector3)item.transform.up;
        }

        alignmentMove /= context.Count;

        return alignmentMove;
    }
}
