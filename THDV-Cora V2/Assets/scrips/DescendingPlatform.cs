using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DescendingPlatform : MonoBehaviour
{
    [SerializeField] private float descendSpeed = 2.0f; // Velocidad de descenso
    [SerializeField] private float descendDistance = 5.0f; // Distancia m�xima de descenso
    private Vector3 initialPosition;
    private Rigidbody rb;
    private bool isDescending = false;
    private float distanceDescended = 0f;

    void Start()
    {
        initialPosition = transform.position; // Guardamos la posici�n inicial de la plataforma
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // Hacemos que el Rigidbody sea cinem�tico para controlar el movimiento
    }

    void FixedUpdate()
    {
        if (isDescending)
        {
            // Calcula el paso de descenso
            float descendStep = descendSpeed * Time.fixedDeltaTime;

            // Mueve la plataforma hacia abajo
            if (distanceDescended < descendDistance)
            {
                // Actualiza la posici�n de la plataforma
                rb.MovePosition(rb.position - new Vector3(0, descendStep, 0));
                distanceDescended += descendStep;
            }
            else
            {
                // Detiene el descenso al alcanzar la distancia m�xima
                isDescending = false;
                distanceDescended = 0f; // Resetea la distancia descendida para un posible reinicio
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isDescending)
        {
            isDescending = true; // Empieza a descender solo en la primera colisi�n
        }
    }

    public void ResetPlatform()
    {
        // M�todo para resetear la plataforma a la posici�n inicial
        transform.position = initialPosition;
        distanceDescended = 0f;
        isDescending = false;
    }
}
