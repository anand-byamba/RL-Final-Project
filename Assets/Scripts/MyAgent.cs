using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class MyAgent : Agent
{
    float speed = 25;

    public GameObject Spawner;

    private Vector3 startingPosition = new Vector3(0.0f, 10, 80);

    private float boundXLeft = -20f;
    private float boundXRight = 20f;

    public override void OnEpisodeBegin()
    {
        // Reset agent position
        transform.localPosition = startingPosition;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // RayPerceptionSensor handles most observations automatically.
        // No manual observations needed for now.
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;

        // Smooth continuous value in range [-1,1]
        continuousActionsOut[0] = Input.GetAxisRaw("Horizontal");
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        ActionSegment<float> continuousActions = actions.ContinuousActions;

        float moveX = continuousActions[0]; // [-1, 1]

        // Apply movement with boundaries
        Vector3 newPos = transform.localPosition;
        newPos.x += moveX * speed * Time.fixedDeltaTime;
        newPos.x = Mathf.Clamp(newPos.x, boundXLeft, boundXRight);

        transform.localPosition = newPos;

        // Small survival reward
        AddReward(0.01f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bird")) // Use CompareTag for performance
        {
            // Give negative reward for collision
            SetReward(-1.0f);

            // Destroy the specific bird that hit the agent (optional, but cleaner)
            Destroy(other.gameObject);

            EndEpisode();
        }
    }
}