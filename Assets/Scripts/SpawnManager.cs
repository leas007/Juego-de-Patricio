using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject monedaPrefab;
    public GameObject patricioPrefab;
    public float tiempoEntreSpawns = 1f;
    public Vector2 limitesX = new Vector2(-7, 7); // Ajusta estos valores según el ancho de tu pantalla.

    private void Start()
    {
        InvokeRepeating("SpawnObjeto", 0f, tiempoEntreSpawns);
    }

    void SpawnObjeto()
    {
        float posX = Random.Range(limitesX.x, limitesX.y);
        Vector3 spawnPosition = new Vector3(posX, transform.position.y, transform.position.z);

        GameObject objetoParaSpawnear;
        if (Random.value > 0.5f)
        {
            objetoParaSpawnear = monedaPrefab;
        }
        else
        {
            objetoParaSpawnear = patricioPrefab;
        }

        Instantiate(objetoParaSpawnear, spawnPosition, Quaternion.identity);
    }
}
