using UnityEngine;

public class ControlArco : MonoBehaviour
{
    public GameObject flechaPrefab2D;
    public GameObject flechaPrefab3D;

    public Transform puntoDisparo;
    public float fuerzaDisparo = 20f;
    public float suavidadRotacion = 5f;

    void Update()
    {
        if (!Camera.main.orthographic)
        {
            RotarArco3D();
            if (Input.GetButtonDown("Fire1")) // Cambia "Fire1" según la configuración de entrada
            {
                DispararFlecha3D();
            }
        }
        else
        {
            RotarArco2D();
            if (Input.GetButtonDown("Fire1")) // Cambia "Fire1" según la configuración de entrada
            {
                DispararFlecha2D();
            }
        }
    }

    void RotarArco3D()
    {
        // Lógica para rotar el arco en 3D
        Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane planoDisparo = new Plane(Camera.main.transform.forward, puntoDisparo.position);

        if (planoDisparo.Raycast(rayo, out float distancia))
        {
            Vector3 puntoInterseccion = rayo.GetPoint(distancia);
            Vector3 direccionDisparo = puntoInterseccion - puntoDisparo.position;
            direccionDisparo.Normalize();
            Quaternion rotacionDeseada = Quaternion.LookRotation(direccionDisparo, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotacionDeseada, suavidadRotacion * Time.deltaTime);
        }
    }

    void DispararFlecha3D()
    {
        GameObject flecha = Instantiate(flechaPrefab3D, puntoDisparo.position, Quaternion.identity);
        // Obtener la dirección de disparo desde la rotación del arco
        Vector3 direccionDisparo = transform.forward; // Utilizamos la dirección del arco
        Rigidbody rbFlecha = flecha.GetComponent<Rigidbody>();
        if (rbFlecha != null)
        {
            rbFlecha.AddForce(direccionDisparo * fuerzaDisparo, ForceMode.Impulse);
        }
    }

    void RotarArco2D()
    {
        // Lógica para rotar el arco en 2D
        Vector3 direccionMouse = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angulo = Mathf.Atan2(direccionMouse.y, direccionMouse.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angulo, Vector3.forward);
    }

    void DispararFlecha2D()
    {
        GameObject flecha = Instantiate(flechaPrefab2D, puntoDisparo.position, Quaternion.identity);
        // Obtener la dirección de disparo en 2D
        Vector3 direccionDisparo = puntoDisparo.right;
        Rigidbody2D rbFlecha = flecha.GetComponent<Rigidbody2D>();
        if (rbFlecha != null)
        {
            rbFlecha.AddForce(direccionDisparo * fuerzaDisparo, ForceMode2D.Impulse);
        }
    }
}

