using UnityEngine;

public class ChaseTriggerZone : MonoBehaviour
{
    public bool _isPlayerDetected { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player _player))
        {
            _isPlayerDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player _player))
        {
            _isPlayerDetected = false;
        }
    }
}
