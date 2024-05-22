using UnityEngine;

public class DibujarTrayectoria : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public int puntosPorTrayectoria = 10;
    public float espacioEntrePuntos = 0.1f;
    public float velocidadInicial = 20f;
    public float gravedad = 9.81f;

    void Update()
    {
        DibujarTrayectoriaFlecha();
    }

    void DibujarTrayectoriaFlecha()
    {
        Vector3[] puntos = new Vector3[puntosPorTrayectoria];
        Vector3 velocidadInicialVector;

        if (Camera.main.orthographic)
        {
            velocidadInicialVector = transform.right * velocidadInicial; // En 2D, la dirección inicial es hacia la derecha
        }
        else
        {
            velocidadInicialVector = transform.forward * velocidadInicial; // En 3D, la dirección inicial es hacia adelante
        }

        for (int i = 0; i < puntosPorTrayectoria; i++)
        {
            float tiempo = i * espacioEntrePuntos;
            puntos[i] = CalcularPosicionEnTiempo(tiempo, velocidadInicialVector, gravedad);
        }

        lineRenderer.positionCount = puntosPorTrayectoria;
        lineRenderer.SetPositions(puntos);
    }

    Vector3 CalcularPosicionEnTiempo(float tiempo, Vector3 velocidadInicial, float gravedad)
    {
        Vector3 posicionHorizontal;
        if (Camera.main.orthographic)
        {
            posicionHorizontal = transform.position + (velocidadInicial * tiempo);
        }
        else
        {
            posicionHorizontal = transform.position + (velocidadInicial * tiempo);
        }

        Vector3 posicionVertical = Vector3.down * (0.5f * gravedad * tiempo * tiempo);
        return posicionHorizontal + posicionVertical;
    }
}

