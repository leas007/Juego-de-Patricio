using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallaInicio : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(CuentaRegresiva());
        }
    }

    IEnumerator CuentaRegresiva()
    {
        // Aquí puedes mostrar una cuenta regresiva visual si lo deseas.
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Gameplay");  // Asegúrate de tener una escena llamada "Gameplay".
    }
}
