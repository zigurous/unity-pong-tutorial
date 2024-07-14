using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BouncySurface : MonoBehaviour
{
    public enum ForceType
    {
        Additive,
        Multiplicative,
    }

    public ForceType forceType = ForceType.Additive;
    public float bounceStrength = 0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball))
        {
            switch (forceType)
            {
                case ForceType.Additive:
                    ball.currentSpeed += bounceStrength;
                    return;

                case ForceType.Multiplicative:
                    ball.currentSpeed *= bounceStrength;
                    return;
            }
        }
    }

}
