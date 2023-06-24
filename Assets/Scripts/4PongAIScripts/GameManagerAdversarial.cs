using UnityEngine;
using UnityEngine.UI;
using Unity.MLAgents;
using System.Collections.Generic;

public class GameManagerAdversarial : MonoBehaviour
{
    public Ball ball;
    private int redAgentGroupScore;
    public Text redAgentScoreText;
    private int blueAgentGroupScore;
    public Text blueAgentScoreText;
    public int maxEnvironmentSteps = 5000;
    private int resetTimer;
    private SimpleMultiAgentGroup blueAgentGroup;
    private SimpleMultiAgentGroup redAgentGroup;
    public List<PaddleAgentAdversarial> agents = new List<PaddleAgentAdversarial>();

    private void Start()
    {
        RegisterAgents();
        StartRound();
    }

    private void RegisterAgents()
    {
        blueAgentGroup = new SimpleMultiAgentGroup();
        redAgentGroup = new SimpleMultiAgentGroup();

        foreach (var agent in agents)
        {
            if (agent.agentTeam == Team.Blue)
            {
                blueAgentGroup.RegisterAgent(agent);
            }
            else
            {
                redAgentGroup.RegisterAgent(agent);
            }
        }
    }

    void FixedUpdate()
    {
        resetTimer += 1;
        if (resetTimer >= maxEnvironmentSteps && maxEnvironmentSteps > 0)
        {
            blueAgentGroup.GroupEpisodeInterrupted();
            redAgentGroup.GroupEpisodeInterrupted();

            StartRound();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            ResetScore();
        }
    }

    public void ResetScore()
    {
        setRedAgentGroupScore(0);
        setBlueAgentGroupScore(0);
    }

    public void redAgentGroupScores()
    {
        setRedAgentGroupScore(redAgentGroupScore + 1);
        redAgentGroup.AddGroupReward(1f);
        blueAgentGroup.AddGroupReward(-1f);

        EndRound();
        StartRound();
    }

    public void blueAgentGroupScores()
    {
        setBlueAgentGroupScore(blueAgentGroupScore + 1);
        redAgentGroup.AddGroupReward(-1f);
        blueAgentGroup.AddGroupReward(1f);

        EndRound();
        StartRound();
    }

    private void setRedAgentGroupScore(int score)
    {
        redAgentGroupScore = score;
        redAgentScoreText.text = score.ToString();
    }

    private void setBlueAgentGroupScore(int score)
    {
        blueAgentGroupScore = score;
        blueAgentScoreText.text = score.ToString();
    }

    public void EndRound()
    {
        redAgentGroup.EndGroupEpisode();
        blueAgentGroup.EndGroupEpisode();
    }

    public void StartRound()
    {
        resetTimer = 0;

        resetAgents();
        resetBall();
    }

    private void resetAgents()
    {
        foreach (var agent in agents)
        {
            float randomYPosition = UnityEngine.Random.Range(-1f, 1f);
            Vector2 newPosition = agent.initialPosition + new Vector2(0f, randomYPosition);

            agent.transform.position = newPosition;
            agent.agentRigidBody.velocity = Vector2.zero;
        }
    }

    private void resetBall()
    {
        ball.ResetPosition();
        ball.AddStartingForce();
    }
}
