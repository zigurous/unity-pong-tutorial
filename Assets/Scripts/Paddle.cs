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
    protected Rigidbody2D _rigidbody;

    private void Awake()
    {
        // Store references to the paddle's components
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void ResetPosition()
    {
        // Stop any motion that might be applied to the paddle
        // and reset the y-axis position to zero
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.position = new Vector2(_rigidbody.position.x, 0.0f);
    }

}
