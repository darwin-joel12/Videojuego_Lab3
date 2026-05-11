using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para reiniciar

public class ControlNave : MonoBehaviour
{
    public float fuerzaSalto = 6f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.up * fuerzaSalto;
        }

        // Límites de la pantalla
        if (transform.position.y > 4.5f)
        {
            transform.position = new Vector3(transform.position.x, 4.5f, transform.position.z);
            rb.linearVelocity = Vector2.zero;
        }
        if (transform.position.y < -4.5f)
        {
            transform.position = new Vector3(transform.position.x, -4.5f, transform.position.z);
            rb.linearVelocity = Vector2.zero;
        }
    }

    // REINICIO AL CHOCAR
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}