using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the state of the game such as scoring and starting new rounds.
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// The ball component.
    /// </summary>
    [Tooltip("The ball component.")]
    public Ball ball;

    /// <summary>
    /// The player's paddle component.
    /// </summary>
    [Tooltip("The player's paddle component.")]
    public Paddle playerPaddle;

    /// <summary>
    /// The current score of the player.
    /// </summary>
    public int playerScore { get; private set; }

    /// <summary>
    /// The UI text that displays the player's score.
    /// </summary>
    [Tooltip("The UI text the displays the player's score.")]
    public Text playerScoreText;

    /// <summary>
    /// The computer's paddle component.
    /// </summary>
    [Tooltip("The computer's paddle component.")]
    public Paddle computerPaddle;

    /// <summary>
    /// The current score of the computer.
    /// </summary>
    public int computerScore { get; private set; }

    /// <summary>
    /// The UI text that displays the computer's score.
    /// </summary>
    [Tooltip("The UI text the displays the computer's score.")]
    public Text computerScoreText;

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            NewGame();
        }
    }

    public void NewGame()
    {
        SetPlayerScore(0);
        SetComputerScore(0);
        StartRound();
    }

    public void StartRound()
    {
        this.playerPaddle.ResetPosition();
        this.computerPaddle.ResetPosition();
        this.ball.ResetPosition();
        this.ball.AddStartingForce();
    }

    public void PlayerScores()
    {
        SetPlayerScore(this.playerScore + 1);
        StartRound();
    }

    public void ComputerScores()
    {
        SetComputerScore(this.computerScore + 1);
        StartRound();
    }

    private void SetPlayerScore(int score)
    {
        this.playerScore = score;
        this.playerScoreText.text = score.ToString();
    }

    private void SetComputerScore(int score)
    {
        this.computerScore = score;
        this.computerScoreText.text = score.ToString();
    }

}
