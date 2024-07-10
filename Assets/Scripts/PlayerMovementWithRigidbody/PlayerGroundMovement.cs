using UnityEngine;

/// <summary>
/// ����� ���������� �� �������� �������������� ������
/// </summary>
public class PlayerGroundMovement
{
    private readonly Rigidbody2D _playerRigidbody;
    private readonly float _moveSpeed;

    public PlayerGroundMovement(Rigidbody2D playerRigidbody, float moveSpeed)
    {
        _playerRigidbody = playerRigidbody;
        _moveSpeed = moveSpeed;
    }

    /// <summary>
    /// ��������� �������������� ������������� ������
    /// </summary>
    /// <param name="movement"></param>
    public void MovePlayerHorizontal(Vector2 movement)
    {
        Vector2 move = new(movement.x * _moveSpeed, _playerRigidbody.velocity.y);
        _playerRigidbody.velocity = move;
    }
}
