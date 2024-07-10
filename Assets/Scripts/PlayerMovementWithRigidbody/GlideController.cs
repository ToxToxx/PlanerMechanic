using UnityEngine;

/// <summary>
/// Класс отвечающий за планирование игрока
/// </summary>
public class GlideController
{
    private readonly Rigidbody2D _playerRigidbody;

    private readonly float _glideGravityScale;
    private readonly float _glideControl;
    private readonly float _initialDrag;

    private bool _isGliding = false;
    public GlideController(Rigidbody2D playerRigidbody, float glideGravityScale, float glideControl)
    {
        _playerRigidbody = playerRigidbody;
        _glideGravityScale = glideGravityScale;
        _glideControl = glideControl;
        _initialDrag = _playerRigidbody.drag;
    }

    /// <summary>
    /// метод отвечающий за управление ввода планирования, когда мы удерживаем кнопку прыжка
    /// </summary>
    /// <param name="jumpIsHeld"></param>
    /// <param name="jumpWasReleased"></param>
    public void HandleGlide(bool jumpIsHeld, bool jumpWasReleased)
    {
        if (jumpIsHeld && _playerRigidbody.velocity.y < 0)
        {
            _isGliding = true;
        }

        if (jumpWasReleased || _playerRigidbody.velocity.y >= 0)
        {
            _isGliding = false;
        }

        _playerRigidbody.gravityScale = _isGliding ? _glideGravityScale : 1f;
    }

    /// <summary>
    /// Сам процесс планирования игрока
    /// </summary>
    public void InitiateGliding()
    {
        if (_isGliding)
        {
            _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, Mathf.Max(_playerRigidbody.velocity.y, -_glideControl));
            _playerRigidbody.drag = _glideGravityScale;
        }
        else
        {
            _playerRigidbody.drag = _initialDrag;
        }
    }
}
