using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class ScoringZone : MonoBehaviour
{
    public UnityEvent scoreTrigger;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball _)) {
            scoreTrigger.Invoke();
        }
    }

}
