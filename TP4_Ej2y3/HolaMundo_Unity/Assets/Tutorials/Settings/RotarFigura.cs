using UnityEngine;
using UnityEngine.InputSystem;

public class RotarFigura : MonoBehaviour
{
    public float velocidad = 100f;

    void Update()
    {
        float horizontal = 0f;
        float vertical = 0f;

        if (Keyboard.current.leftArrowKey.isPressed)
            horizontal = -1f;

        if (Keyboard.current.rightArrowKey.isPressed)
            horizontal = 1f;

        if (Keyboard.current.upArrowKey.isPressed)
            vertical = 1f;

        if (Keyboard.current.downArrowKey.isPressed)
            vertical = -1f;

        transform.Rotate(
            vertical * velocidad * Time.deltaTime,
            horizontal * velocidad * Time.deltaTime,
            0f
        );
    }
}