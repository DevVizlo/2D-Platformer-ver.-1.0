using UnityEngine;

namespace Scripts.Player
    {
        public class PlayerShoot : MonoBehaviour
        {
            [Header("Снаряд")]
            [SerializeField] private FireBallPlayer _fireBall;

            private void Update()
            {
                bool isClickMouse = Input.GetKeyDown(KeyCode.Mouse0);
                if (isClickMouse)
                    Instantiate(_fireBall, transform.position, Quaternion.identity);
            }
        }
    }
