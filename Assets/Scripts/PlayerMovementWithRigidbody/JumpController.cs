using UnityEngine;

/// <summary>
/// ����� ���������� �� ���������� �������� ������
/// </summary>
public class JumpController
{
    private readonly Rigidbody2D _playerRigidbody;
    private readonly float _jumpForce;

    public JumpController(Rigidbody2D playerRigidbody, float jumpForce)
    {
        _playerRigidbody = playerRigidbody;
        _jumpForce = jumpForce;
    }

    /// <summary>
    /// ��������� ����� ������ � ���������� ������
    /// </summary>
    /// <param name="jumpWasPressed"></param>
    public void HandleJump(bool jumpWasPressed)
    {
        if (jumpWasPressed && Mathf.Abs(_playerRigidbody.velocity.y) < 0.1f)
        {
            _playerRigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}
