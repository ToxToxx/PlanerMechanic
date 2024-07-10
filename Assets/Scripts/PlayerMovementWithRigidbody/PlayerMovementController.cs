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

    private bool _isFacingRight = true;

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
        FlipPlayer(InputManager.Movement);
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


    /// <summary>
    /// ����� ��� �������� ������ ����� � ������
    /// </summary>
    private void FlipPlayer(Vector2 movement)
    {
        if (movement.x > 0 && !_isFacingRight)
        {
            Flip();
        }
        else if (movement.x < 0 && _isFacingRight)
        {
            Flip();
        }
    }

    /// <summary>
    /// ������������ ����������� ������
    /// </summary>
    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
