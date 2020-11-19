using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the state of the game, such as
/// scoring, and starting a new game and round.
/// </summary>
public class GameManager : MonoBehaviour
{
    private int _playerScore = 0;

    /// <summary>
    /// The current score of the player.
    /// </summary>
    public int playerScore
    {
        get => _playerScore;
        private set
        {
            _playerScore = value;
            // Update the UI anytime the score changes
            this.playerScoreText.text = _playerScore.ToString();
        }
    }

    private int _computerScore = 0;

    /// <summary>
    /// The current score of the computer.
    /// </summary>
    public int computerScore
    {
        get => _computerScore;
        private set
        {
            _computerScore = value;
            // Update the UI anytime the score changes
            this.computerScoreText.text = _computerScore.ToString();
        }
    }

    [Header("References")]
    public Ball ball;
    public Paddle playerPaddle;
    public Paddle computerPaddle;
    public Text playerScoreText;
    public Text computerScoreText;

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        // Start a new game by pressing 'R'
        if (Input.GetKeyDown(KeyCode.R)) {
            NewGame();
        }
    }

    public void NewGame()
    {
        // Reset the score
        this.playerScore = 0;
        this.computerScore = 0;

        // Start the first round
        StartRound();
    }

    public void StartRound()
    {
        // Reset the positions of all the objects
        this.playerPaddle.ResetPosition();
        this.computerPaddle.ResetPosition();
        this.ball.ResetPosition();

        // Add the initial starting force of the ball
        this.ball.AddStartingForce();
    }

    public void PlayerScores()
    {
        this.playerScore++;

        // Immediately start a new round
        // after the player scores
        StartRound();
    }

    public void ComputerScores()
    {
        this.computerScore++;

        // Immediately start a new round
        // after the computer scores
        StartRound();
    }

}
