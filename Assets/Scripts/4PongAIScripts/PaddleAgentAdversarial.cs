using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Policies;

public enum Team
{
    Blue = 0,
    Red = 1
}

public class PaddleAgentAdversarial : Agent
{
    [HideInInspector]
    public Team agentTeam;
    public float speed = 8f;
    public Rigidbody2D agentRigidBody;
    public Ball ball;
    public Vector2 initialPosition;
    BehaviorParameters behaviorParameters;

    public override void Initialize()
    {
        behaviorParameters = gameObject.GetComponent<BehaviorParameters>();
        if (behaviorParameters.TeamId == (int) Team.Blue)
        {
            agentTeam = Team.Blue;
        }
        else
        {
            agentTeam = Team.Red;
        }
        initialPosition = new Vector2(transform.position.x, transform.position.y);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(agentRigidBody.position.y);
        sensor.AddObservation(ball.rigidbody.position);
        sensor.AddObservation(ball.rigidbody.velocity);

        Vector2 directionToBall = (ball.rigidbody.position - agentRigidBody.position).normalized;
        sensor.AddObservation(directionToBall);

        Vector2 distanceToBall = ball.rigidbody.position - agentRigidBody.position;
        sensor.AddObservation(distanceToBall);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveInYAxis = actions.ContinuousActions[0];
        float xPosition = agentRigidBody.position.x;
        Vector2 direction = new Vector2(xPosition, moveInYAxis);

        agentRigidBody.AddForce(direction * speed);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            continuousActions[0] = 1f;
        } else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            continuousActions[0] = -1f;
        } else {
            continuousActions[0] = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball")) {
            AddReward(.2f);
        }
    }
}
