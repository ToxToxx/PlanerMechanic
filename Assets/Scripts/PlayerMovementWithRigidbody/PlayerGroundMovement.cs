using UnityEngine;

/// <summary>
/// Класс отвечающий за движение горизонтальное игрока
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
    /// управлене горизонтальным передвижением игрока
    /// </summary>
    /// <param name="movement"></param>
    public void MovePlayerHorizontal(Vector2 movement)
    {
        Vector2 move = new(movement.x * _moveSpeed, _playerRigidbody.velocity.y);
        _playerRigidbody.velocity = move;
    }
}
