using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private JumpController jumpController;
    private GlideController glideController;

    void Start()
    {
        jumpController = GetComponent<JumpController>();
        glideController = GetComponent<GlideController>();
    }

    void Update()
    {
        // ������
        Vector3 move = new Vector3(InputManager.Movement.x, 0, InputManager.Movement.y) * moveSpeed * Time.deltaTime;
        transform.Translate(move, Space.World);

        // ��������� ������
        jumpController.HandleJump(InputManager.JumpWasPressed);

        // ��������� ������������
        glideController.HandleGlide(InputManager.JumpIsHeld, InputManager.JumpWasReleased);
    }
}
