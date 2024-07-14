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
    private CapsuleCollider2D boxCollider2D;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravedadInicial = rb.gravityScale;
        boxCollider2D = GetComponent<CapsuleCollider2D>();
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
        // Detectar la escalera y habilitar la escalada
        bool enEscalera = DetectarEscalera();
        if (enEscalera)
        {
            Escalar();
        }
        else
        {
            rb.gravityScale = gravedadInicial; // Restaurar la gravedad cuando no está en una escalera
        }
    }

    private void Mover(float direccion)
    {
        Vector2 fuerzaMovimiento = new Vector2(direccion * velocidadMovimiento, rb.velocity.y);
        rb.velocity = fuerzaMovimiento;
    }

    private void Saltar()
    {
        // Aplicar impulso hacia arriba solo si el personaje está en el suelo
        if (Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
        }
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
        // Definir el tamaño y la posición del área de detección de la escalera
        Vector2 posicionCentro = boxCollider2D.bounds.center;
        Vector2 tamañoBox = new Vector2(boxCollider2D.bounds.size.x, boxCollider2D.bounds.size.y * 1.5f);

        // Verificar si el área se solapa con la capa "Escalera"
        LayerMask capaEscalera = LayerMask.GetMask("Escalera");
        Collider2D collider = Physics2D.OverlapBox(posicionCentro, tamañoBox, 0f, capaEscalera);

        // Devolver true si se detecta una escalera
        return collider != null;
    }

    private void Escalar()
    {
        // Controla el movimiento vertical en la escalera
        float movimientoVertical = Input.GetAxis("Vertical");
        Vector2 fuerzaVertical = new Vector2(rb.velocity.x, movimientoVertical * velocidadEscalera);
        rb.velocity = fuerzaVertical;
    }
    private void OnDrawGizmos()
    {
        if (boxCollider2D != null)
        {
            Gizmos.color = Color.red;
            Vector2 posicionCentro = boxCollider2D.bounds.center;
            Vector2 tamañoBox = new Vector2(boxCollider2D.bounds.size.x, boxCollider2D.bounds.size.y * 1.5f);
            Gizmos.DrawWireCube(posicionCentro, tamañoBox);
        }
    }
}



