using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _player.TriggerCharacter(collision);
    }
}
