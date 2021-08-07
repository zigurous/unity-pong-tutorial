using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Paddle : MonoBehaviour
{
    public float speed = 8.0f;
    public new Rigidbody2D rigidbody { get; private set; }

    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
    }

    public void ResetPosition()
    {
        this.rigidbody.velocity = Vector2.zero;
        this.rigidbody.position = new Vector2(this.rigidbody.position.x, 0.0f);
    }

}
