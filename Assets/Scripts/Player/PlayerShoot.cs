using UnityEngine;

namespace Scripts.Player
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] private FireBallPlayer _fireBall;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                Instantiate(_fireBall, transform.position, Quaternion.identity);
        }
    }
}
