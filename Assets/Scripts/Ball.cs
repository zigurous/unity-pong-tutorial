using UnityEngine;

/// <summary>
/// Handles the physics/movement of the ball.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    /// <summary>
    /// The base speed of the ball.
    /// </summary>
    [Tooltip("The base speed of the ball.")]
    public float speed = 200.0f;

    /// <summary>
    /// The rigidbody component attached to the ball.
    /// </summary>
    public new Rigidbody2D rigidbody { get; private set; }

    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
    }

    public void ResetPosition()
    {
        // Stop any motion applied to the ball and reset the position
        this.rigidbody.velocity = Vector2.zero;
        this.rigidbody.position = Vector2.zero;
    }

    public void AddStartingForce()
    {
        // Flip a coin to determine if the ball starts left or right
        float x = Random.value < 0.5f ? -1.0f : 1.0f;

        // Flip a coin to determine if the ball goes up or down. Set the range
        // between 0.5 -> 1.0 to ensure it does not move completely horizontal.
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f)
                                      : Random.Range(0.5f, 1.0f);

        // Apply the force to the ball by multiplying direction and speed
        Vector2 direction = new Vector2(x, y);
        this.rigidbody.AddForce(direction * this.speed);
    }

    public void AddForce(Vector2 force)
    {
        this.rigidbody.AddForce(force);
    }

}
