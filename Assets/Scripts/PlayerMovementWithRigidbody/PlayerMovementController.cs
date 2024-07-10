using UnityEngine;

/// <summary>
/// ������, �������������� �������� ��������, ������ ��� ��� ����, ����� ��������� ���������� ���������, � ����� ������� ������ ������� Rigidbody
/// </summary>

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private PlayerMovementStats _playerMovementStats;

    private PlayerGroundMovement _playerGroundMovement;
    private JumpController _jumpController;
    private GlideController _glideController;
    private Rigidbody2D _playerRigidbody;

    private void Awake()
    {
        InitiateComponents(); 
    }


    /// <summary>
    /// ��������� ����� ������
    /// </summary>
    private void Update()
    {
        HandlePlayerInput();
    }

    private void FixedUpdate()
    {
        // ��������� ������������, ����� ���� ���� ����� ������� �� ����� � ��������� �������
        _glideController.InitiateGliding();
    }


    /// <summary>
    /// ������������� ����������� �������� � ��������� ����� ��� �������������
    /// </summary>
    private void InitiateComponents()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();

        _playerGroundMovement = new PlayerGroundMovement(_playerRigidbody, _playerMovementStats.MoveSpeed);
        _jumpController = new JumpController(_playerRigidbody, _playerMovementStats.JumpForce);
        _glideController = new GlideController(_playerRigidbody, _playerMovementStats.GlideGravityScale, _playerMovementStats.GlideControl);
    }

    /// <summary>
    /// ��������� ����� ����������� ������ ������
    /// </summary>
    private void HandlePlayerInput()
    {
        // ��������� ����� ��� ������
        _playerGroundMovement.MovePlayerHorizontal(InputManager.Movement);

        // ��������� ����� ��� ������
        _jumpController.HandleJump(InputManager.JumpWasPressed);

        // ��������� ����� ��� ������������
        _glideController.HandleGlide(InputManager.JumpIsHeld, InputManager.JumpWasReleased);
    }
}
