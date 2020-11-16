using UnityEngine;

/// <summary>
/// Handles moving the player's paddle based on
/// user input.
/// </summary>
public class PlayerPaddle : Paddle
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            // Move the position of the paddle up
            // while factoring in speed over time
            this.transform.position += Vector3.up * this.speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            // Move the position of the paddle down
            // while factoring in speed over time
            this.transform.position += Vector3.down * this.speed * Time.deltaTime;
        }
    }

}
