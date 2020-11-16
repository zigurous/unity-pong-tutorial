using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Triggers a score event when the ball collides
/// with the zone.
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
public class ScoringZone : MonoBehaviour
{
    /// <summary>
    /// The event triggered when a player scores.
    /// </summary>
    [Tooltip("The event triggered when a player scores.")]
    public EventTrigger.TriggerEvent scoreTrigger;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Get a reference to the ball from the colliding object
        Ball ball = collision.gameObject.GetComponent<Ball>();

        // If the ball collided with the zone then the
        // reference will not be null
        if (ball != null)
        {
            // Invoke the event trigger callback
            BaseEventData eventData = new BaseEventData(EventSystem.current);
            eventData.selectedObject = this.gameObject;
            this.scoreTrigger.Invoke(eventData);
        }
    }

}
