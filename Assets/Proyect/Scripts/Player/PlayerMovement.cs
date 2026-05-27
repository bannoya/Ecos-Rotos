using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        Vector2 moveInput = Keyboard.current != null ?
            new Vector2(
                (Keyboard.current.dKey.isPressed ? 1f : 0f) - (Keyboard.current.aKey.isPressed ? 1f : 0f),0
            ) : Vector2.zero;

        // Usa moveInput para mover el transform (ejemplo simple)
        if (moveInput != Vector2.zero)
            transform.Translate((Vector3)moveInput.normalized * speed * Time.deltaTime, Space.World);
    }

}
