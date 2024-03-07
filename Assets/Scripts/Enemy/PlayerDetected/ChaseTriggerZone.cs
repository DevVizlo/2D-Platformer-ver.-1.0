using UnityEngine;

public class ChaseTriggerZone : MonoBehaviour
{
    public bool _isPlayerDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _isPlayerDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _isPlayerDetected = false;
        }
    }
}
