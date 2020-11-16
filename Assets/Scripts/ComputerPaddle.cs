using UnityEngine;

/// <summary>
/// Handles moving the computer's paddle
/// through simple artificial intelligence.
/// </summary>
public class ComputerPaddle : Paddle
{
    /// <summary>
    /// A reference to the ball so the computer can track its position.
    /// </summary>
    [Tooltip("A reference to the ball so the computer can track its position.")]
    public Ball ball;

    /// <summary>
    /// The number of seconds it takes the computer
    /// to respond to changes in the ball's position.
    /// </summary>
    [Tooltip("The number of seconds it takes the computer to respond to changes in the ball's position.")]
    public float reactionTime = 0.1f;

    /// <summary>
    /// The rate of change of the paddle's position.
    /// </summary>
    private Vector3 _velocity;

    private void Update()
    {
        Vector3 currentPosition = this.transform.position;

        // Track the position of the ball in the y-axis
        Vector3 desiredPosition = currentPosition;
        desiredPosition.y = this.ball.transform.position.y;

        if (this.reactionTime > 0.0f)
        {
            // Slowly move the position of the paddle toward
            // the desired position based on the computer's
            // reaction time and max speed
            this.transform.position = Vector3.SmoothDamp(
                current: currentPosition,
                target: desiredPosition,
                currentVelocity: ref _velocity,
                smoothTime: this.reactionTime,
                maxSpeed: this.speed);
        }
        else
        {
            // If there is no reaction time then
            // set the desired position immediately
            this.transform.position = desiredPosition;
        }
    }

}
