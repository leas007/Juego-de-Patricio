using UnityEngine;

public class MoverTubo : MonoBehaviour
{
    public float velocidad = 1f;

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(movimientoHorizontal, 0, 0) * velocidad * Time.deltaTime);
    }
}
