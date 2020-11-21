using UnityEngine;

/// <summary>
/// Handles moving the computer's paddle
/// through simple artificial intelligence.
/// </summary>
public class ComputerPaddle : Paddle
{
    /// <summary>
    /// A reference to the ball so the computer can
    /// track its position.
    /// </summary>
    [Tooltip("A reference to the ball so the computer can track its position.")]
    public Rigidbody2D ball;

    private void FixedUpdate()
    {
        // Check if the ball is moving towards the paddle (positive x velocity)
        // or away from the paddle (negative x velocity)
        if (this.ball.velocity.x > 0.0f)
        {
            // Track the position of the ball and move towards it
            // so it can be hit
            if (this.ball.position.y > _rigidbody.position.y) {
                _rigidbody.AddForce(Vector2.up * this.speed);
            } else if (this.ball.position.y < _rigidbody.position.y) {
                _rigidbody.AddForce(Vector2.down * this.speed);
            }
        }
        else
        {
            // Move towards the center of the field and idle there
            // until the ball starts coming towards the paddle again
            if (_rigidbody.position.y > 0.0f) {
                _rigidbody.AddForce(Vector2.down * this.speed);
            } else if (_rigidbody.position.y < 0.0f) {
                _rigidbody.AddForce(Vector2.up * this.speed);
            }
        }
    }

}
