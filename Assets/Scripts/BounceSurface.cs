using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BounceSurface : MonoBehaviour
{
    public float bounceStrength;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            // Apply a force to the ball in the opposite direction of the
            // surface to make it bounce off
            Vector2 normal = collision.GetContact(0).normal;
            ball.AddForce(-normal * this.bounceStrength);
        }
    }

}
