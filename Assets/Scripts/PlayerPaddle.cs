using UnityEngine;

/// <summary>
/// Handles moving the player's paddle based on user input.
/// </summary>
public class PlayerPaddle : Paddle
{
    /// <summary>
    /// The direction the player is moving.
    /// </summary>
    public Vector2 direction { get; private set; }

    private void Update()
    {
        // Set the direction of the paddle based on the input key being pressed
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            this.direction = Vector2.up;
        } else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            this.direction = Vector2.down;
        } else {
            this.direction = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        // Move the paddle by applying a force in the set direction
        if (this.direction.sqrMagnitude != 0) {
            this.rigidbody.AddForce(this.direction * this.speed);
        }
    }

}
