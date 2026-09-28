using UnityEngine;
using UnityEngine.InputSystem;

public class HomeroController : MonoBehaviour
{
    public Material[] texturasHomero;

    public float velocidad = 20f;

    private int indexTexturasHomero = 0;

    private float rotacionX = 0f;
    private float rotacionY = 0f;

    private float velocidadX = 0f;
    private float velocidadY = 0f;

    private Renderer rendererHomero;

    void Start()
    {
        rendererHomero = GetComponent<Renderer>();

        rendererHomero.material = texturasHomero[indexTexturasHomero];
    }

    void Update()
    {
        Keyboard teclado = Keyboard.current;

        if (teclado == null)
            return;

        // ↑
        if (teclado.upArrowKey.wasPressedThisFrame)
        {
            velocidadX = -velocidad;
            velocidadY = 0;
        }

        // ↓
        if (teclado.downArrowKey.wasPressedThisFrame)
        {
            velocidadX = velocidad;
            velocidadY = 0;
        }

        // ←
        if (teclado.leftArrowKey.wasPressedThisFrame)
        {
            velocidadY = -velocidad;
            velocidadX = 0;
        }

        // →
        if (teclado.rightArrowKey.wasPressedThisFrame)
        {
            velocidadY = velocidad;
            velocidadX = 0;
        }

        // D = detener
        if (teclado.dKey.wasPressedThisFrame)
        {
            velocidadX = 0;
            velocidadY = 0;
        }

        // R = cambiar textura
        if (teclado.rKey.wasPressedThisFrame)
        {
            CambiarTextura();
        }

        // Movimiento de rotación
        rotacionX += velocidadX * Time.deltaTime;
        rotacionY += velocidadY * Time.deltaTime;

        transform.rotation = Quaternion.Euler(
            rotacionX,
            rotacionY,
            0f
        );
    }

    void CambiarTextura()
    {
        indexTexturasHomero++;

        if (indexTexturasHomero >= texturasHomero.Length)
        {
            indexTexturasHomero = 0;
        }

        rendererHomero.material = texturasHomero[indexTexturasHomero];

        rotacionX = 0f;
        rotacionY = 0f;

        velocidadX = 0f;
        velocidadY = 0f;
    }
}