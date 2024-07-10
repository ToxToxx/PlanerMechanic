using UnityEngine;

/// <summary>
/// ������� ��� ������� �������� � ��������������� �������� ������������ ��
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
    /// ��������� ��������� ��������
    /// </summary>
    private void UpdateAnimationStates()
    {
        // ��������� ���������� � ����
        bool isRunning = Mathf.Abs(InputManager.Movement.x) > 0.1f;
        _animator.SetBool(IS_RUNNING, isRunning);

        // ��������� ���������� � ������
        bool isJumping = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y) > 0.1f;
        _animator.SetBool(IS_JUMPING, isJumping);

        // ���� �� ��, �� ������ - ������ Idle
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
