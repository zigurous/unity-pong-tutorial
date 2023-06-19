using UnityEngine;
using UnityEngine.UI;

public class GameManagerAI : MonoBehaviour
{
    public Ball ball;
    public PaddleAgent redAgent;
    private int redAgentScore;
    public Text redAgentScoreText;
    public PaddleAgent blueAgent;
    private int blueAgentScore;
    public Text blueAgentScoreText;

    private void Start()
    {
        NewGame();
    }

    private void FixedUpdate() {
        // UpdateBallSpeePeriodically();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            NewGame();
        }
    }

    public void NewGame()
    {
        setRedAgentScore(0);
        setBlueAgentScore(0);
        StartRound();
    }

    public void redAgentScores()
    {
        setRedAgentScore(redAgentScore + 1);
        redAgent.AddReward(.1f);
        blueAgent.AddReward(-.5f);
        StartRound();
    }

    public void blueAgentScores()
    {
        setBlueAgentScore(blueAgentScore + 1);
        redAgent.AddReward(-.5f);
        blueAgent.AddReward(.1f);
        StartRound();
    }

    private void setRedAgentScore(int score)
    {
        redAgentScore = score;
        redAgentScoreText.text = score.ToString();
    }

    private void setBlueAgentScore(int score)
    {
        blueAgentScore = score;
        blueAgentScoreText.text = score.ToString();
    }

    public void StartRound()
    {
        redAgent.OnEpisodeBegin();
        blueAgent.OnEpisodeBegin();

        ball.ResetPosition();
        ball.AddStartingForce();
    }

    private void UpdateBallSpeePeriodically()
    {
        if (ball.speed >= 400f) {
            Debug.Log("Ball speed is maxed out");
            return;
        }

        float speedAmountToBeAdded = .000001f;
        float newBallSpeed = ball.speed + speedAmountToBeAdded;

        Debug.Log("Ball speed: " + newBallSpeed);
        ball.speed = newBallSpeed;
    }

}
