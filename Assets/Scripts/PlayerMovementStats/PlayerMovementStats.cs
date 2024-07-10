using UnityEngine;

/// <summary>
/// Скриптовый объект отвечающий за параметры героя - добавлены ползунки мин-макса, которые в дальнейшем может от регулировать ГД
/// Также благодаря ползункам можно более удобно настраивать статы передвижения
/// </summary>
[CreateAssetMenu(menuName = "Player Movement Stats")]
public class PlayerMovementStats : ScriptableObject
{
    [Header("Movement")]
    [Range(5f, 15f)] public float MoveSpeed = 5f;

    [Header("Jump")]
    [Range(25f, 100f)] public float JumpForce = 5f;

    [Header("Glide")]
    [Range(0f, 1f)] public float GlideGravityScale = 0.5f;
    [Range(1f, 5f)] public float GlideControl = 2.0f;
}
