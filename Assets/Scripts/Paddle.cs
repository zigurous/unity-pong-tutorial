using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Paddle : MonoBehaviour
{
    /// <summary>
    /// How quickly the paddle moves up and down.
    /// </summary>
    [Tooltip("How quickly the paddle moves up and down.")]
    public float speed = 5.0f;

    /// <summary>
    /// The rigidbody component attached to the paddle.
    /// </summary>
    protected Rigidbody2D _rigidbody;

    protected virtual void Awake()
    {
        // Store references to the paddle's components
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void ResetPosition()
    {
        // Set the y-axis position to zero while keeping
        // the x-axis and z-axis the same
        this.transform.position = new Vector3(this.transform.position.x, 0.0f, this.transform.position.z);

        // Stop any motion that might be applied to the paddle
        _rigidbody.velocity = Vector2.zero;
    }

}
