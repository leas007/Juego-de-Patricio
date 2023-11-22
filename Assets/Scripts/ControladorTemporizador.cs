using UnityEngine;
using TMPro; 

public class ControladorTemporizador : MonoBehaviour
{
    public GameObject pantallaResultado;
    public GameObject objetoTemporizador;
    public GameObject objetoResultado;

    private TextMeshProUGUI textoResultado;
    private TextMeshProUGUI textoTemporizador;

    public float tiempoRestante = 60f;

    public AudioClip sonidoGanador;
    public AudioClip sonidoPerdedor;
    private AudioSource audioSource;

    public AudioSource audioFondo;


    private bool juegoFinalizado = false;



    private void Start()
    {
        if (objetoTemporizador)
        {
            audioSource = GetComponent<AudioSource>();

            textoTemporizador = objetoTemporizador.GetComponent<TextMeshProUGUI>();
            if (textoTemporizador == null)
            {
                Debug.LogError("Componente TextMeshProUGUI no encontrado en " + objetoTemporizador.name);
            }
        }
        else
        {
            Debug.LogError("Objeto Temporizador no asignado en el script.");
        }

        if (objetoResultado)
        {
            textoResultado = objetoResultado.GetComponent<TextMeshProUGUI>();
            if (textoResultado == null)
            {
                Debug.LogError("Componente TextMeshProUGUI no encontrado en " + objetoResultado.name);
            }
        }
        else
        {
            Debug.LogError("Objeto Resultado no asignado en el script.");
        }
    }

    private void Update()
    {
        tiempoRestante -= Time.deltaTime;
        if (textoTemporizador)
        {
            textoTemporizador.text = "Tiempo: " + Mathf.Round(tiempoRestante).ToString();
        }

        if (tiempoRestante <= 0)
        {
            tiempoRestante = 0;
            FinalizarJuego();
        }
    }

    void FinalizarJuego()
    {

        if (juegoFinalizado) return; // Si el juego ya finalizó, salimos del método
    
        juegoFinalizado = true; // Marcar el juego como finalizado
        ControladorMarcador marcador = FindObjectOfType<ControladorMarcador>(); // <-- Mover esta línea al principio

        Time.timeScale = 0; // Esto hará que la velocidad del juego se configure a 0, efectivamente pausando todo movimiento y lógica del juego.

        AudioSource audioFondo = FindObjectOfType<AudioSource>();
        if (audioFondo != null)
        {
            audioFondo.Stop();
        }

        if (marcador.puntos >= 60)
        {
            if (sonidoGanador != null)
            {
                audioSource.PlayOneShot(sonidoGanador);
            }
        }
        else
        {
            if (sonidoPerdedor != null)
            {
                audioSource.PlayOneShot(sonidoPerdedor);
            }
        }

        pantallaResultado.SetActive(true);
        if (marcador.puntos >= 60)
        {
            textoResultado.text = "¡Ganaste! Felicidades.";
        }
        else
        {
            textoResultado.text = "No lograste recolectar los 60 puntos.";
        }
}

}
