using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class InputHandler : MonoBehaviour
{
    private Player _playerVampirizm;
    private PlayerMover _playerMover;

    private bool _isJump;
    private bool isMove;
    bool _isVampirizmActivation;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _playerVampirizm = GetComponent<Player>();
    }
    private void Update()
    {
        isMove = Input.GetKey(KeyCode.D);
        _playerMover.MoveHorizontal(isMove);

        _isVampirizmActivation = Input.GetKeyDown(KeyCode.R);
        _playerVampirizm.SpellActivation(_isVampirizmActivation);
    }

    private void FixedUpdate() 
    {
        _isJump = Input.GetKeyDown(KeyCode.Space);
        _playerMover.PlayerJump(_isJump);
    }
}