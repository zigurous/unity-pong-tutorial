using UnityEngine;

/// <summary>
/// Increases the speed of the ball after bouncing
/// off the surface.
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
public class BounceSurface : MonoBehaviour
{
    /// <summary>
    /// The percent increase of the ball's speed after
    /// bouncing off the surface.
    /// </summary>
    [Tooltip("The percent increase of the ball's speed after bouncing off the surface.")]
    public float bounceSpeedIncrease = 1.01f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Get a reference to the ball from the colliding object
        Ball ball = collision.gameObject.GetComponent<Ball>();

        // If the ball collided with the surface then the
        // reference will not be null
        if (ball != null) {
            ball.IncreaseSpeed(this.bounceSpeedIncrease);
        }
    }

}
