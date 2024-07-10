using UnityEngine;

/// <summary>
/// добавил для красоты анимации и соответствующий контролёр переключения их
/// </summary>
[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    private const string IS_RUNNING = "Is_Running";
    private const string IS_JUMPING = "Is_Jumping";
    private const string IS_IDLE = "Is_Idle";

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateAnimationStates();
    }

    /// <summary>
    /// Обновляем состояния анимаций
    /// </summary>
    private void UpdateAnimationStates()
    {
        // обновляем информацию о беге
        bool isRunning = Mathf.Abs(InputManager.Movement.x) > 0.1f;
        _animator.SetBool(IS_RUNNING, isRunning);

        // обновляем информацию о прыжке
        bool isJumping = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y) > 0.1f;
        _animator.SetBool(IS_JUMPING, isJumping);

        // Если ни то, ни другое - значит Idle
        if (!isRunning && !isJumping)
        {
            _animator.SetBool(IS_IDLE, true);
        }
        else
        {
            _animator.SetBool(IS_IDLE, false);
        }
    }
}
