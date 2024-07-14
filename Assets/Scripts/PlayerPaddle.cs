using UnityEngine;

/// <summary>
/// Handles moving the player's paddle based on
/// user input.
/// </summary>
public class PlayerPaddle : Paddle
{
    /// <summary>
    /// The direction the player is moving.
    /// 1=up, -1=down, 0=none
    /// </summary>
    private int _direction = 0;

    private void Update()
    {
        // Set the direction of the paddle
        // based on the input key being pressed
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            _direction = 1;
        } else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            _direction = -1;
        } else {
            _direction = 0;
        }
    }

    private void FixedUpdate()
    {
        // Move the paddle by applying a force
        // in the direction the player is moving
        if (_direction != 0) {
            _rigidbody.AddForce(new Vector2(0.0f, _direction) * this.speed);
        }
    }

}
