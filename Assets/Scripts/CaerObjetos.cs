using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CaerObjetos : MonoBehaviour
{
    public float velocidadCaida = 10f;
    public int valorPuntos = 1;

    public AudioClip sonidoMoneda;
    public AudioClip sonidoPatricio;
    public AudioClip sonidoQuitaPuntos; // Nuevo sonido
    private AudioSource audioSource;

    void Update()
    {
        transform.Translate(new Vector3(0, -1, 0) * velocidadCaida * Time.deltaTime);

        if (transform.position.y < -100)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tubo"))
        {
            ControladorMarcador marcador = FindObjectOfType<ControladorMarcador>();
            if (this.CompareTag("Moneda"))
            {
                if (sonidoMoneda != null)
                {
                    audioSource.PlayOneShot(sonidoMoneda);
                }
                marcador.AñadirPuntos(1);
                Destroy(this.gameObject);
            }
            else if (this.CompareTag("Patricio"))
            {
                if (sonidoPatricio != null)
                {
                    audioSource.PlayOneShot(sonidoPatricio);
                }
                marcador.AñadirPuntos(2);
                Destroy(this.gameObject);
            }
            else if (this.CompareTag("QuitaPuntos")) // Nueva condición
            {
                if (sonidoQuitaPuntos != null)
                {
                    audioSource.PlayOneShot(sonidoQuitaPuntos);
                }
                marcador.RestarPuntos(3); // Asumiendo que tienes un método llamado "RestarPuntos" en tu ControladorMarcador
                Destroy(this.gameObject);
            }
        }
    }
}
