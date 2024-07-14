using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Triggers a score event when the ball collides with the zone.
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
public class ScoringZone : MonoBehaviour
{
    /// <summary>
    /// The event triggered when a player scores.
    /// </summary>
    [Tooltip("The event triggered when a player scores.")]
    public UnityEvent scoreTrigger;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        // If the ball is null then we collided with something else
        if (ball != null) {
            this.scoreTrigger.Invoke();
        }
    }

}
