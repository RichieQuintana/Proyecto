using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] float fuerzaSalto = 5f;
    [SerializeField] float velocidadMovimiento = 3f;
    [SerializeField] float velocidadEscalera = 2f; // Ajusta según tus necesidades
    private Rigidbody2D rb;
    private bool mirandoDerecha = true;
    private float gravedadInicial;
    private BoxCollider2D boxCollider2D;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravedadInicial = rb.gravityScale;
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Saltar();
        }

        float movimientoHorizontal = Input.GetAxis("Horizontal");
        Mover(movimientoHorizontal);

        if (movimientoHorizontal > 0 && !mirandoDerecha)
        {
            Girar();
        }
        else if (movimientoHorizontal < 0 && mirandoDerecha)
        {
            Girar();
        }

        // Detectar la escalera y habilitar la escalada
        bool enEscalera = DetectarEscalera();
        if (enEscalera)
        {
            Escalar();
        }
    }

    private void Mover(float direccion)
    {
        Vector2 fuerzaMovimiento = new Vector2(direccion * velocidadMovimiento, rb.velocity.y);
        rb.velocity = fuerzaMovimiento;
    }

    private void Saltar()
    {
        rb.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private bool DetectarEscalera()
    {
        // Implementa la detección de la escalera aquí (OverlapBox o OverlapCircle)
        // Devuelve true si está en la escalera, false si no
        // Puedes usar boxCollider2D.bounds para obtener el área del personaje
        // y verificar si se superpone con la escalera
        return false; // Cambia esto según tu implementación
    }

    private void Escalar()
    {
        // Controla el movimiento vertical en la escalera
        float movimientoVertical = Input.GetAxis("Vertical");
        Vector2 fuerzaVertical = new Vector2(rb.velocity.x, movimientoVertical * velocidadEscalera);
        rb.velocity = fuerzaVertical;
    }
}



