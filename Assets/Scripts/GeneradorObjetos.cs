using UnityEngine;

public class GeneradorObjetos : MonoBehaviour
{
    public GameObject monedaPrefab;
    public GameObject patricioPrefab;
    public GameObject quitaPuntosPrefab; // Nuevo prefab para quitar puntos
    public float intervalo = 1f; // Generar cada 1 segundo
    private float tiempoContador;

    private void Update()
    {
        tiempoContador += Time.deltaTime;

        if (tiempoContador >= intervalo)
        {
            GenerarObjeto();
            tiempoContador = 0f;
        }
    }

    void GenerarObjeto()
    {
        GameObject objetoAGenerar;

        int eleccion = Random.Range(0, 3); // Ahora hay 3 opciones
        switch(eleccion)
        {
            case 0:
                objetoAGenerar = monedaPrefab;
                break;
            case 1:
                objetoAGenerar = patricioPrefab;
                break;
            default:
                objetoAGenerar = quitaPuntosPrefab; // Añadir la opción de quitar puntos
                break;
        }

        // Define una posición aleatoria para la generación
        float posicionX = Random.Range(-8f, 8f); // Estos valores son solo un ejemplo, ajústalos según el tamaño y la escala de tu escenario
        float posicionY = transform.position.y;  // Asume que el generador está en la posición Y correcta

        Instantiate(objetoAGenerar, new Vector3(posicionX, posicionY, 0), Quaternion.identity);
    }
}
