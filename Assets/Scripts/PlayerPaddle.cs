using UnityEngine;

/// <summary>
/// Handles moving the player's paddle based on
/// user input.
/// </summary>
public class PlayerPaddle : Paddle
{
    /// <summary>
    /// The direction the player is moving.
    /// </summary>
    private Vector2 _direction;

    private void Update()
    {
        // Set the direction of the paddle
        // based on the input key being pressed
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            _direction = Vector2.up;
        } else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            _direction = Vector2.down;
        } else {
            _direction = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        // Move the paddle by applying a force
        // in the direction the player is moving
        if (_direction.sqrMagnitude != 0) {
            _rigidbody.AddForce(_direction * this.speed);
        }
    }

}
