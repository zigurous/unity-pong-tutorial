using UnityEngine;

/// <summary>
/// Handles moving the player's paddle based on
/// user input.
/// </summary>
public class PlayerPaddle : Paddle
{
    private void Update()
    {
        // Move the position of the paddle up or down
        // based on the input key being pressed
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            // Change the position by multiplying
            // direction and speed over time
            this.transform.position += Vector3.up * this.speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            // Change the position by multiplying
            // direction and speed over time
            this.transform.position += Vector3.down * this.speed * Time.deltaTime;
        }
    }

}
