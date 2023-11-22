using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorJuego : MonoBehaviour
{
    public void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Esto recargará la escena actual.
    }

    public void SalirJuego()
    {
        Application.Quit(); // Esto cerrará la aplicación. Nota: No funcionará en el editor, solo en el juego compilado.
    }
}
