using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    // Prefab Setup 
    public FlockAgent agentPrefab;
    List<FlockAgent> agents = new List<FlockAgent>();
    public FlockBehaviour behaviour;

    // Agent Size Determinants
    [Range(10, 500)]
    public int startingCount = 250;                                                 // Defines the starting size of the flock
    const float AgentDensity = 0.08f;

    // Agent Behaviour Controllers
    [Range(1f, 100f)]
    public float driveFactor = 10f;                                                 // Controls the speed of the agents
    [Range(1f, 100f)]
    public float maxSpeed = 5f;                                                     // Limits the agent speed.
    [Range(1f, 10f)]
    public float neighbourRadius = 1.5f;                                            // Radius checking for nearby entities to the flock.
    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    // Utility Variables
    float squareMaxSpeed;
    float squareNeighbourRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

    // Start is called before the first frame update
    void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighbourRadius = neighbourRadius * neighbourRadius;
        squareAvoidanceRadius = squareNeighbourRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        for (int i = 0; i<startingCount; i++)
        {
            FlockAgent newAgent = Instantiate(
                agentPrefab,
                Random.insideUnitSphere * startingCount * AgentDensity,                                         // Note that, use InsideUnitCircle for 2D, and InsideUnitSphere for 3D
                Quaternion.Euler(Vector3.up * Random.Range(0f, 360f)),
                transform);
            
            newAgent.name = "Agent " + i;
            agents.Add(newAgent);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
