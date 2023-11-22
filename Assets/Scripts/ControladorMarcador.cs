using UnityEngine;
using TMPro;  // Asegúrate de tener esta línea

public class ControladorMarcador : MonoBehaviour
{
    public int puntos = 0;
    public GameObject objetoMarcador;
    public TextMeshProUGUI textoMarcador;

    private void Start()
    {
        if (textoMarcador == null && objetoMarcador != null)
        {
            textoMarcador = objetoMarcador.GetComponent<TextMeshProUGUI>();
            if (textoMarcador == null)
            {
                Debug.LogError("Componente TextMeshProUGUI no encontrado en " + objetoMarcador.name);
                return;
            }
        }
        else if(textoMarcador == null)
        {
            Debug.LogError("Referencia a textoMarcador no establecida.");
            return;
        }

        ActualizarMarcador();
    }

    public void AñadirPuntos(int puntosAñadidos)
    {
        puntos += puntosAñadidos;
        ActualizarMarcador();
    }

    // Nuevo método para restar puntos
    public void RestarPuntos(int puntosRestados)
    {
        puntos -= puntosRestados;
        // Evitar que los puntos se vuelvan negativos
        if (puntos < 0)
        {
            puntos = 0;
        }
        ActualizarMarcador();
    }

    private void ActualizarMarcador()
    {
        textoMarcador.text = "Puntos: " + puntos;
    }
}
