using UnityEngine;

/// <summary>
/// Adds a force to the ball after bouncing off the surface.
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
public class BounceSurface : MonoBehaviour
{
    /// <summary>
    /// The strength of the force added to the ball after
    /// bouncing off the surface.
    /// </summary>
    [Tooltip("The strength of the force added to the ball after bouncing off the surface.")]
    public float bounceStrength;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Get a reference to the ball from the colliding object
        Ball ball = collision.gameObject.GetComponent<Ball>();

        // If the ball collided with the surface then the
        // reference will not be null
        if (ball != null)
        {
            // Apply a force to the ball in the
            // opposite direction of the surface
            Vector2 normal = collision.GetContact(0).normal;
            ball.AddForce(-normal * this.bounceStrength);
        }
    }

}
