using UnityEngine;

/// <summary>
/// Скрипт, контролирующий основное движение, сделан был для того, чтобы уменьшить количество монобехов, а также сделать меньше вызовов Rigidbody
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
    /// Обработка ввода игрока
    /// </summary>
    private void Update()
    {
        HandlePlayerInput();
        FlipPlayer(InputManager.Movement);
    }

    private void FixedUpdate()
    {
        // Инициация планирования, здесь пока один метод поэтому не вынес в отдельную функцию
        _glideController.InitiateGliding();
    }


    /// <summary>
    /// инициализация компонентов вынесена в отдельнйы метод для читабельности
    /// </summary>
    private void InitiateComponents()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();

        _playerGroundMovement = new PlayerGroundMovement(_playerRigidbody, _playerMovementStats.MoveSpeed);
        _jumpController = new JumpController(_playerRigidbody, _playerMovementStats.JumpForce);
        _glideController = new GlideController(_playerRigidbody, _playerMovementStats.GlideGravityScale, _playerMovementStats.GlideControl);
    }

    /// <summary>
    /// отдельный метод управляющий вводом игрока
    /// </summary>
    private void HandlePlayerInput()
    {
        // Обработка ввода для ходьбы
        _playerGroundMovement.MovePlayerHorizontal(InputManager.Movement);

        // Обработка ввода для прыжка
        _jumpController.HandleJump(InputManager.JumpWasPressed);

        // Обработка ввода для планирования
        _glideController.HandleGlide(InputManager.JumpIsHeld, InputManager.JumpWasReleased);
    }


    /// <summary>
    /// Метод для поворота игрока влево и вправо
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
    /// Переключение направления игрока
    /// </summary>
    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
