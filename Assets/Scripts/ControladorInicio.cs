using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cargar escenas

public class ControladorInicio : MonoBehaviour
{
    
    public GameObject elementosDelJuego; // Referencia al objeto que contiene todos los elementos del juego
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))  // Detecta si se presionó la tecla ENTER
        {
            IniciarJuego();
        }
    }

    void IniciarJuego()
    {
        // Desactiva el Canvas de inicio
        gameObject.SetActive(false);
        // Aquí puedes agregar cualquier otra lógica necesaria para iniciar el juego, 
        // como cargar una nueva escena, si lo prefieres.
        // Ejemplo: SceneManager.LoadScene("NombreDeTuEscenaDeJuego");
        // Activa todos los elementos del juego
        elementosDelJuego.SetActive(true);
    }
}
