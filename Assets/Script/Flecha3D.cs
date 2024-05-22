using UnityEngine;

public class Flecha3D : MonoBehaviour
{
    private Rigidbody rb;
    private TrailRenderer trail;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        trail = GetComponent<TrailRenderer>();
    }

    void Update()
    {
        if (rb.velocity != Vector3.zero)
        {
            trail.enabled = true;
            // Rotar la flecha en la dirección de su velocidad (3D)
            transform.rotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
        }
        else
        {
            trail.enabled = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Si la etiqueta coincide, destruir la flecha
            Destroy(gameObject);
        }
    }
}
