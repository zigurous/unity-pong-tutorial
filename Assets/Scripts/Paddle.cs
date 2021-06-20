using UnityEngine;

/// <summary>
/// Defines the base properties of a paddle.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Paddle : MonoBehaviour
{
    /// <summary>
    /// How quickly the paddle moves up and down.
    /// </summary>
    [Tooltip("How quickly the paddle moves up and down.")]
    public float speed = 8.0f;

    /// <summary>
    /// The rigidbody component attached to the paddle.
    /// </summary>
    public new Rigidbody2D rigidbody { get; private set; }

    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
    }

    public void ResetPosition()
    {
        // Stop any motion that might be applied to the paddle and reset the
        // y-axis position to zero
        this.rigidbody.velocity = Vector2.zero;
        this.rigidbody.position = new Vector2(this.rigidbody.position.x, 0.0f);
    }

}
