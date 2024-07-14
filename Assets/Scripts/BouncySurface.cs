using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BouncySurface : MonoBehaviour
{
    public float bounceStrength = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            // Apply a force to the ball in the opposite direction of the
            // surface to make it bounce off
            Vector2 normal = collision.GetContact(0).normal;
            ball.rigidbody.AddForce(-normal * bounceStrength, ForceMode2D.Impulse);
        }
    }

}
