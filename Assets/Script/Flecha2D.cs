using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha2D : MonoBehaviour
{
    private Rigidbody2D rb;
    private TrailRenderer trail;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trail = GetComponent<TrailRenderer>();
    }

    void Update()
    {
        if (rb.velocity != Vector2.zero)
        {
            trail.enabled = true;
            // Rotar la flecha en la dirección de su velocidad (2D)
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else
        {
            trail.enabled = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Si la etiqueta coincide, destruir la flecha
            Destroy(gameObject);
        }
    }
}
